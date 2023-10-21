using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MiniULTHack.Collections
{
    static class Extensions
    {
        public static void Sort<T, TKey>(this ReloadableObservableCollection<T> collection, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
        {
            List<T> sorted = collection.ToList();
            sorted.Sort((a,b) => keySelector.Invoke(a).CompareTo(keySelector.Invoke(b)));
            for (int i = 0; i < sorted.Count(); i++)
                collection.Move(collection.IndexOf(sorted[i]), i);
        }
    }

    public class ReloadableObservableCollection<T> : ObservableCollection<T>
    {

        public void ReplaceData(IEnumerable<T> items)
        {
            ReloadData(
                innerList =>
                {
                    foreach (var item in items)
                    {
                        innerList.Add(item);
                    }
                });
        }

        public void ReloadData(Action<IList<T>> innerListAction)
        {
            Items.Clear();

            innerListAction(Items);

            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            OnPropertyChanged(new PropertyChangedEventArgs("Items[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public async Task ReloadDataAsync(Func<IList<T>, Task> innerListAction)
        {
            Items.Clear();

            await innerListAction(Items);

            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            OnPropertyChanged(new PropertyChangedEventArgs("Items[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
