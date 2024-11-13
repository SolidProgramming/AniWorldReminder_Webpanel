using System.Diagnostics.CodeAnalysis;

namespace AniWorldReminder_Webpanel.Classes
{
    public class SeriesEqualityComparer : IEqualityComparer<SeriesModel>
    {
        public bool Equals(SeriesModel? x, SeriesModel? y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x is null || y is null)
                return false;

            return x.Id == y.Id
                && x.Name == y.Name
                && x.Path == y.Path;
        }

        public int GetHashCode([DisallowNull] SeriesModel series)
        {
            return series.Id.GetHashCode() ^ series.Name.GetHashCode() ^ series.Path.GetHashCode();
        }
    }
}
