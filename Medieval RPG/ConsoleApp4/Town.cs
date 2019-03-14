class Town
    {
        protected string townName;
        protected string townFlavor;
        protected string townOptions;
        /*protected string storeName;
        protected string storeFlavor;
        protected string storeOptions;*/



    public Town(string name, string flavor, string options)
    {
        townName = name;
        townFlavor = flavor;
        townOptions = options;
    }

    public void setlocation(string name, string flavor, string options)
    {
        townName = name;
        townFlavor = flavor;
        townOptions = options;
    }

        public string getName() { return townName; }
        public string getFlavor() { return townFlavor; }
        public string getOptions() { return townOptions; }
}

