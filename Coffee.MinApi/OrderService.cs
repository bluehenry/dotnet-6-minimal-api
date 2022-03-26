namespace Coffee.MinApi
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        Order GetOrderById(int id);
        Order AddOrder(Order order);
        void UpdateOrder(int id, Order newOrder);
        void DeleteOrder(int id);
    }
    public class OrderService : IOrderService
    {
        private OrderDbContext _context;

        public OrderService(OrderDbContext context)
        {
            _context = context;
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void UpdateOrder(int id, Order newOrder)
        {
            if (newOrder != null)
            {
                var order = _context.Orders.FirstOrDefault(x => x.Id == id);
                if (order != null)
                {
                    order.Description = newOrder.Description;
                    order.PromoCode = newOrder.PromoCode;
                    order.Total = newOrder.Total;
                    order.OrderNumber = newOrder.OrderNumber;
                    _context.SaveChanges();
                }
            }
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
