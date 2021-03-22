namespace Flight_Agency.utils.observer
{
    public abstract class IObservable
    {
        public abstract void addObserver(IObserver o);
        public abstract void removeObserver(IObserver o);
        public abstract void notifyObservers();
    }
}