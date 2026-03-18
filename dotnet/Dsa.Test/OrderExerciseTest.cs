namespace Dsa.Test;

public class OrderExerciseTest
{
    [Fact]
    public void Should_calculate_orders_total_quantity_when_processing()
    {
        var order1 = new Order
        {
            Id = 1,
            Price = 299,
            Category = "Eletrônicos"
        };
        var order2 = new Order
        {
            Id = 2,
            Price = 15,
            Category = "Roupas"
        };
        var expectedTotal = 2;
        var orderProcessor = new OrderProcessor();

        orderProcessor.Process(order1);
        orderProcessor.Process(order2);

        Assert.Equal(expectedTotal, orderProcessor.TotalQuantity);
    }

    [Fact]
    public void Should_summarize_orders_total_price_when_processing()
    {
        var order1 = new Order
        {
            Id = 1,
            Price = 299,
            Category = "Eletrônicos"
        };
        var order2 = new Order
        {
            Id = 2,
            Price = 15,
            Category = "Roupas"
        };
        var expectedTotalPrice = 314;
        var orderProcessor = new OrderProcessor();

        orderProcessor.Process(order1);
        orderProcessor.Process(order2);

        Assert.Equal(expectedTotalPrice, orderProcessor.TotalPrice);
    }

    [Fact]
    public void Should_calculate_orders_total_by_category()
    {
        var category = "Eletrônicos";
        var order1 = new Order
        {
            Id = 1,
            Price = 299,
            Category = category
        };
        var order2 = new Order
        {
            Id = 2,
            Price = 15,
            Category = "Roupas"
        };
        var expectedTotal = order1.Price;
        var orderProcessor = new OrderProcessor();

        orderProcessor.Process(order1);
        orderProcessor.Process(order2);
        var total = orderProcessor.TotalByCategory(category);

        Assert.Equal(expectedTotal, total);
    }
}