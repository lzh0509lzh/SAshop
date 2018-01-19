using System;
using System.Collections.Generic;
using System.Linq;

namespace SaAPI.Utility.Error
{
    public static class EnumerableExtension
    {
        public static TResultType GetMax<TSourceType, TComparerType, TResultType>(
            this IEnumerable<TSourceType> source,
            Func<TSourceType, TComparerType> srcSelector,
            Func<TComparerType, TResultType> retSelector) where TComparerType : IComparable
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var sourceTypes = source as TSourceType[] ?? source.ToArray();
            int cnt = sourceTypes.Count();
            if (cnt == 0)
            {
                throw new ArgumentException("There is no element in the source.");
            }

            var maxEle = srcSelector(sourceTypes[0]);
            if (cnt == 1)
            {
                return retSelector(maxEle);
            }

            for (int i = 1; i < cnt; i++)
            {
                var cur = srcSelector(sourceTypes[i]);
                if (cur.CompareTo(maxEle) > 0)
                {
                    maxEle = cur;
                }
            }

            return retSelector(maxEle);
        }
    }
}