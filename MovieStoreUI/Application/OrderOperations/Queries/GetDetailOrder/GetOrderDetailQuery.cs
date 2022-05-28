using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.OrderOperations.Queries.GetDetailOrder
{
    public class GetOrderDetailQuery
    {
        public int OrderId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrderDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public OrderDetailViewModel Handle()
        {
            var order = _dbContext.Orders
            .Include(o =>o.Customer)
            .Include(m => m.Movie)
            .FirstOrDefault(x => x.Id == OrderId);

            if(order is null) throw new InvalidOperationException("Sipariş Bulunamadı...");
            OrderDetailViewModel viewModel = _mapper.Map<OrderDetailViewModel>(order);

            return viewModel;
        }

    }
    public class OrderDetailViewModel
    {
        public string Customer { get; set; }
        public string Movie { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderPrice { get; set; }
        public bool IsVisible { get; set; }
    }
}