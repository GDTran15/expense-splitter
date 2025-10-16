namespace WebApplication1.Util
{
    public static class SplittingPayment
    {

        public static double SplittingPaymentForFriends(double payment)
        {
            return payment / 2;
        }
        public static double SplittingPaymentForGroups(double payment, int numberOfMembers)
        {
            return (double) payment / numberOfMembers;
        }
    }
}
