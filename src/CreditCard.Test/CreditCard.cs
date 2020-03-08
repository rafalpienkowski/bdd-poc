using System;

namespace CreditCard.Test
{
    public class CreditCard
    {
        private readonly Guid _id;
        private decimal? _limit = null;
        public decimal AvaliableLimit => _limit.HasValue ? _limit.Value : 0;

        public CreditCard(Guid id)
        {
            _id = id;
        }

        public void AssignLimit(decimal limit)
        {
            if (_limit.HasValue)
            {
                throw new InvalidOperationException("");
            }

            _limit = limit;
        }

        public void WithDraw(decimal amount)
        {
            if (amount > _limit)
            {
                throw new InvalidOperationException("");
            }

            _limit -= amount;
        }

        public void Repay(decimal amount)
        {
            _limit += amount;
        }
    }
}
