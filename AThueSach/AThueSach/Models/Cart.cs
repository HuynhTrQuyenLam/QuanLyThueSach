﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AThueSach.Models
{
    public class CartItems
    {
        // Khai báo một mục sản phẩm mua CartItem
        public Product _product { get; set; }
        public int _quantity { get; set; }
    }
    public class Cart
    {
        // Dùng List để lưu trữ giỏ hàng là một bảng tạm
        List<CartItems> items = new List<CartItems>();
        public IEnumerable<CartItems> Items
        {
            get { return items; }
        }
        // Phương thức lấy sản phẩm bỏ vào giỏ hàng
        public void Add_Product_Cart(Product _pro, int _quan = 1)
        {
            var item = Items.FirstOrDefault(s => s._product.ProductID == _pro.ProductID);
            if (item == null)
                items.Add(new CartItems { _product = _pro, _quantity = _quan });
            else
                item._quantity += _quan;
        }
        public int Total_product()
        {
            return items.Count();
        }
        // Phương thức tính tổng số lượng trong giỏ hàng
        public int Total_quantity()
        {
            return items.Sum(s => s._quantity);
        }
        // Hàm tính thành tiền cho mỗi sản phẩm trong giỏ hàng
        public decimal Total_money()
        {
            var total = items.Sum(s => s._quantity * s._product.Price);
            return (decimal)total;
        }
        // Phương thức cập nhật số lượng khi khách hàng chọn SP mua thêm
        public void Update_quantity(int id, int _new_quan)
        {
            var item = items.Find(s => s._product.ProductID == id);
            if (item != null)
            {
                if (items.Find(s => s._product.Quantity > _new_quan) != null)
                    item._quantity = _new_quan;
                else item._quantity = 1;
            }               
        }
        // Phương thức xóa sản phẩm trong giỏ hàng
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._product.ProductID == id);
        }
        // Phương thức xóa giỏ hàng (sau khi khách hàng thanh toán xong đơn hàng)
        public void ClearCart()
        {
            items.Clear();
        }

    }
}
