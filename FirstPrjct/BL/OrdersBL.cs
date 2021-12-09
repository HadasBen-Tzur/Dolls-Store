using DL;
using Ent;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrdersBL : IOrdersBL
    {
        IOrdersDL _OrdersDL;
        IProductsDL _productsDL;
        ILogger<OrdersBL> _logger;
        public OrdersBL(IOrdersDL OrdersDL, IProductsDL productsDL, ILogger<OrdersBL> logger)
        {
            _OrdersDL = OrdersDL;
            _productsDL = productsDL;
            _logger = logger;
        }

        public async Task<List<Orders>> GetOrder(short id)
        {
            return await _OrdersDL.GetOrder(id);
        }

        public async Task<Orders> AddOrder(Orders order)
        {
            int sum = 0;
            OrdersItem[] orderItemArr = order.OrdersItem.ToArray();
            List<Products> productsList = await _productsDL.GetAllProducts();
            for (int i = 0; i < orderItemArr.Length; i++)
            {
                for (int j = 0; j < productsList.Count; j++)
                {
                    if (orderItemArr[i].ProductId == productsList[j].ProductId)
                    {
                        sum += productsList[j].Price.Value;
                        break;
                    }
                }
            }
            string sumString = sum.ToString() + "₪";
            if (!sumString.Equals(order.OrderSum))
                _logger.LogInformation("caution!! we found something worng in the sum of paying in {0} user", order.UserId);
            order.OrderSum = sumString;
            return await _OrdersDL.AddOrder(order);
        }
    }
}