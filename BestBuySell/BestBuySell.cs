void Main()
{
	BestBuySell.Tests();
}

class BestBuySell
{
    public static void FindBuySellPoints(double[] prices, out int buy, out int sell)
    {
        buy = sell = 0;
        if (prices.Length == 0)
        {
            return;
        }
        int iMin = 0;
        int iBuy = 0, iSell = 0;
        for (int i=0; i < prices.Length; i++)
        {
            // do we have a better sell point?
            if (prices[i] - prices[iMin] > prices[iSell] - prices[iBuy])
            {
                // update buy and sell points
                iSell = i;
                iBuy = iMin;
            }
            // update the minimum price point
            // this is the best buy point for all future sales
            if (prices[i] < prices[iMin])
            {
                iMin = i;
            }
        }
        buy = iBuy;
        sell = iSell;
    }

    internal static void Tests()
    {
        int bestBuy, bestSell;
        double[] increasing = new double[5] { 0.1, 0.2, 0.3, 0.4, 0.5};
        double[] decreasing = new double[5] { 0.5, 0.4, 0.3, 0.2, 0.1};
        double[] peak = new double[5] { 0.1, 0.2, 0.3, 0.2, 0.1};
        double[] valley = new double[5] { 0.5, 0.4, 0.3, 0.4, 0.5};
		double[] multiPeak = new double[11] { 0.6, 0.4, 0.3, 0.4, 0.5, 0.3, 0.2, 0.5, 0.3, 0.1, 0.3};
		
        FindBuySellPoints(increasing, out bestBuy, out bestSell);
		Console.WriteLine("Increasing {0},{1}", bestBuy, bestSell);
        FindBuySellPoints(decreasing, out bestBuy, out bestSell);
		Console.WriteLine("Decreasing {0},{1}", bestBuy, bestSell);
		FindBuySellPoints(peak, out bestBuy, out bestSell);
		Console.WriteLine("peak {0},{1}", bestBuy, bestSell);
		FindBuySellPoints(valley, out bestBuy, out bestSell);
		Console.WriteLine("valley {0},{1}", bestBuy, bestSell);		
		FindBuySellPoints(multiPeak, out bestBuy, out bestSell);
		Console.WriteLine("MultiPeak {0},{1}", bestBuy, bestSell);
	}
}