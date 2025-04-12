using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WHS.Application.GenericValidtor
{
    public class BaseQueryValidator<T> : AbstractValidator<T> where T : class
    {
        private readonly int[] _allowedPageSizes;
        private readonly string[] _allowedSortColumns;

        public BaseQueryValidator(int[] allowedPageSizes, string[] allowedSortColumns)
        {
            _allowedPageSizes = allowedPageSizes;
            _allowedSortColumns = allowedSortColumns;

            RuleFor(x => GetPropertyValue<int>(x, "PageNumber"))
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page number must be greater than or equal to 1.");

            RuleFor(x => GetPropertyValue<int>(x, "PageSize"))
                .Must(value => _allowedPageSizes.Contains(value))
                .WithMessage($"Page size must be in [{string.Join(", ", _allowedPageSizes)}].");

            RuleFor(x => GetPropertyValue<string>(x, "SortBy"))
                .Must(value => string.IsNullOrEmpty(value) || _allowedSortColumns.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(", ", _allowedSortColumns)}].");
        }

        private static TProp? GetPropertyValue<TProp>(object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (property == null) throw new ArgumentException($"Property '{propertyName}' not found on type '{obj.GetType().Name}'.");

            var value = property.GetValue(obj);
            return value == null ? default : (TProp)value;
        }
    }
}
