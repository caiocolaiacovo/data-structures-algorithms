namespace Dsa.Test;

public class LinkedListTest
{
    [Fact]
    public void Should_print_all_values1()
    {
        var a = new LinkedList.Node("a");
        var b = new LinkedList.Node("b");
        var c = new LinkedList.Node("c");
        var d = new LinkedList.Node("d");
        a.Next = b;
        b.Next = c;
        c.Next = d;
        var expectedValues = new string[] { "a", "b", "c", "d" };

        var valuesIterative = LinkedList.PrintAllValuesIterative(a);
        var valuesRecursive = LinkedList.PrintAllValuesRecursive(a);

        Assert.Equal(expectedValues, valuesIterative);
        Assert.Equal(expectedValues, valuesRecursive);
    }

    [Fact]
    public void Should_print_all_values2()
    {
        var x = new LinkedList.Node("x");
        var y = new LinkedList.Node("y");
        x.Next = y;
        var expectedValues = new string[] { "x", "y" };

        var valuesIterative = LinkedList.PrintAllValuesIterative(x);
        var valuesRecursive = LinkedList.PrintAllValuesRecursive(x);

        Assert.Equal(expectedValues, valuesIterative);
        Assert.Equal(expectedValues, valuesRecursive);
    }

    [Fact]
    public void Should_print_all_values3()
    {
        var q = new LinkedList.Node("q");
        var expectedValues = new string[] { "q" };

        var valuesIterative = LinkedList.PrintAllValuesIterative(q);
        var valuesRecursive = LinkedList.PrintAllValuesRecursive(q);

        Assert.Equal(expectedValues, valuesIterative);
        Assert.Equal(expectedValues, valuesRecursive);
    }

    [Fact]
    public void Should_print_all_values4()
    {
        var valuesIterative = LinkedList.PrintAllValuesIterative(null);
        var valuesRecursive = LinkedList.PrintAllValuesRecursive(null);

        Assert.Empty(valuesIterative);
        Assert.Empty(valuesRecursive);
    }

    [Fact]
    public void Should_zipper_lists1()
    {
        // a -> b -> c
        var a = new LinkedList.Node("a");
        var b = new LinkedList.Node("b");
        var c = new LinkedList.Node("c");
        a.Next = b;
        b.Next = c;
        // x -> y -> z
        var x = new LinkedList.Node("x");
        var y = new LinkedList.Node("y");
        var z = new LinkedList.Node("z");
        x.Next = y;
        y.Next = z;

        var head = LinkedList.ZipperLists(a, x);

        // a -> x -> b -> y -> c -> z
        Assert.Equal(a, head);
        Assert.Equal(x, head.Next);
        Assert.Equal(b, head.Next.Next);
        Assert.Equal(y, head.Next.Next.Next);
        Assert.Equal(c, head.Next.Next.Next.Next);
        Assert.Equal(z, head.Next.Next.Next.Next.Next);
        Assert.Null(head.Next.Next.Next.Next.Next.Next);
    }

    [Fact]
    public void Should_zipper_lists2()
    {
        // a -> b -> c -> d -> e -> f
        var a = new LinkedList.Node("a");
        var b = new LinkedList.Node("b");
        var c = new LinkedList.Node("c");
        var d = new LinkedList.Node("d");
        var e = new LinkedList.Node("e");
        var f = new LinkedList.Node("f");
        a.Next = b;
        b.Next = c;
        c.Next = d;
        d.Next = e;
        e.Next = f;
        // x -> y -> z
        var x = new LinkedList.Node("x");
        var y = new LinkedList.Node("y");
        var z = new LinkedList.Node("z");
        x.Next = y;
        y.Next = z;
        
        var head = LinkedList.ZipperLists(a, x);

        // a -> x -> b -> y -> c -> z -> d -> e -> f
        Assert.Equal(a, head);
        Assert.Equal(x, head.Next);
        Assert.Equal(b, head.Next.Next);
        Assert.Equal(y, head.Next.Next.Next);
        Assert.Equal(c, head.Next.Next.Next.Next);
        Assert.Equal(z, head.Next.Next.Next.Next.Next);
        Assert.Equal(d, head.Next.Next.Next.Next.Next.Next);
        Assert.Equal(e, head.Next.Next.Next.Next.Next.Next.Next);
        Assert.Equal(f, head.Next.Next.Next.Next.Next.Next.Next.Next);
        Assert.Null(head.Next.Next.Next.Next.Next.Next.Next.Next.Next);
    }

    [Fact]
    public void Should_zipper_lists3()
    {
        // s -> t
        var s = new LinkedList.Node("s");
        var t = new LinkedList.Node("t");
        s.Next = t;
        // 1 -> 2 -> 3 -> 4
        var one = new LinkedList.Node("1");
        var two = new LinkedList.Node("2");
        var three = new LinkedList.Node("3");
        var four = new LinkedList.Node("4");
        one.Next = two;
        two.Next = three;
        three.Next = four;

        var head = LinkedList.ZipperLists(s, one);

        // s -> 1 -> t -> 2 -> 3 -> 4
        Assert.Equal(s, head);
        Assert.Equal(one, head.Next);
        Assert.Equal(t, head.Next.Next);
        Assert.Equal(two, head.Next.Next.Next);
        Assert.Equal(three, head.Next.Next.Next.Next);
        Assert.Equal(four, head.Next.Next.Next.Next.Next);
        Assert.Null(head.Next.Next.Next.Next.Next.Next);
    }

    [Fact]
    public void Should_zipper_lists4()
    {
        var w = new LinkedList.Node("w");
        // 1 -> 2 -> 3 
        var one = new LinkedList.Node("1");
        var two = new LinkedList.Node("2");
        var three = new LinkedList.Node("3");
        one.Next = two;
        two.Next = three;

        var head = LinkedList.ZipperLists(w, one);

        // w -> 1 -> 2 -> 3
        Assert.Equal(w, head);
        Assert.Equal(one, head.Next);
        Assert.Equal(two, head.Next.Next);
        Assert.Equal(three, head.Next.Next.Next);
        Assert.Null(head.Next.Next.Next.Next);
    }

    [Fact]
    public void Should_zipper_lists5()
    {
        // 1 -> 2 -> 3
        var one = new LinkedList.Node("1");
        var two = new LinkedList.Node("2");
        var three = new LinkedList.Node("3");
        one.Next = two;
        two.Next = three;
        var w = new LinkedList.Node("w");

        var head = LinkedList.ZipperLists(one, w);

        // 1 -> w -> 2 -> 3
        Assert.Equal(one, head);
        Assert.Equal(w, head.Next);
        Assert.Equal(two, head.Next.Next);
        Assert.Equal(three, head.Next.Next.Next);
        Assert.Null(head.Next.Next.Next.Next);
    }

    [Fact]
    public void Should_sum_list1()
    {
        var a = new LinkedList.Node("2");
        var b = new LinkedList.Node("8");
        var c = new LinkedList.Node("3");
        var d = new LinkedList.Node("-1");
        var e = new LinkedList.Node("7");
        a.Next = b;
        b.Next = c;
        c.Next = d;
        d.Next = e;
        var expectedTotal = 19;

        var totalIterative = LinkedList.SumListIterative(a);
        var totalRecursive = LinkedList.SumListRecursive(a);

        Assert.Equal(expectedTotal, totalIterative);
        Assert.Equal(expectedTotal, totalRecursive);
    }

    [Fact]
    public void Should_sum_list2()
    {
        var x = new LinkedList.Node("38");
        var y = new LinkedList.Node("4");
        x.Next = y;
        var expectedTotal = 42;

        var totalIterative = LinkedList.SumListIterative(x);
        var totalRecursive = LinkedList.SumListRecursive(x);

        Assert.Equal(expectedTotal, totalIterative);
        Assert.Equal(expectedTotal, totalRecursive);
    }

    [Fact]
    public void Should_sum_list3()
    {
        var x = new LinkedList.Node("38");
        var expectedTotal = 38;

        var totalIterative = LinkedList.SumListIterative(x);
        var totalRecursive = LinkedList.SumListRecursive(x);

        Assert.Equal(expectedTotal, totalIterative);
        Assert.Equal(expectedTotal, totalRecursive);
    }

    [Fact]
    public void Should_sum_list4()
    {
        var expectedTotal = 0;

        var totalIterative = LinkedList.SumListIterative(null);
        var totalRecursive = LinkedList.SumListRecursive(null);

        Assert.Equal(expectedTotal, totalIterative);
        Assert.Equal(expectedTotal, totalRecursive);
    }

    [Fact]
    public void Should_reverse_list_iterative1()
    {
        // a -> b -> c -> d -> e -> f
        var a = new LinkedList.Node("a");
        var b = new LinkedList.Node("b");
        var c = new LinkedList.Node("c");
        var d = new LinkedList.Node("d");
        var e = new LinkedList.Node("e");
        var f = new LinkedList.Node("f");
        a.Next = b;
        b.Next = c;
        c.Next = d;
        d.Next = e;
        e.Next = f;

        var head = LinkedList.ReverseListIterative(a);

        // f -> e -> d -> c -> b -> a
        Assert.Equal(f, head);
        Assert.Equal(e, head.Next);
        Assert.Equal(d, head.Next.Next);
        Assert.Equal(c, head.Next.Next.Next);
        Assert.Equal(b, head.Next.Next.Next.Next);
        Assert.Equal(a, head.Next.Next.Next.Next.Next);
        Assert.Null(head.Next.Next.Next.Next.Next.Next);
    }

    [Fact]
    public void Should_reverse_list_iterative2()
    {
        // x -> y
        var x = new LinkedList.Node("x");
        var y = new LinkedList.Node("y");
        x.Next = y;

        var head = LinkedList.ReverseListIterative(x);

        // y -> x
        Assert.Equal(y, head);
        Assert.Equal(x, head.Next);
        Assert.Null(head.Next.Next);
    }

    [Fact]
    public void Should_reverse_list_iterative3()
    {
        var p = new LinkedList.Node("p");

        var head = LinkedList.ReverseListIterative(p);

        Assert.Equal(p, head);
        Assert.Null(head.Next);
    }

    [Fact]
    public void Should_reverse_list_recursive1()
    {
        // a -> b -> c -> d -> e -> f
        var a = new LinkedList.Node("a");
        var b = new LinkedList.Node("b");
        var c = new LinkedList.Node("c");
        var d = new LinkedList.Node("d");
        var e = new LinkedList.Node("e");
        var f = new LinkedList.Node("f");
        a.Next = b;
        b.Next = c;
        c.Next = d;
        d.Next = e;
        e.Next = f;

        var head = LinkedList.ReverseListRecursive(a);

        // f -> e -> d -> c -> b -> a
        Assert.Equal(f, head);
        Assert.Equal(e, head.Next);
        Assert.Equal(d, head.Next.Next);
        Assert.Equal(c, head.Next.Next.Next);
        Assert.Equal(b, head.Next.Next.Next.Next);
        Assert.Equal(a, head.Next.Next.Next.Next.Next);
        Assert.Null(head.Next.Next.Next.Next.Next.Next);
    }

    [Fact]
    public void Should_reverse_list_recursive2()
    {
        // x -> y
        var x = new LinkedList.Node("x");
        var y = new LinkedList.Node("y");
        x.Next = y;

        var head = LinkedList.ReverseListRecursive(x);

        // y -> x
        Assert.Equal(y, head);
        Assert.Equal(x, head.Next);
        Assert.Null(head.Next.Next);
    }

    [Fact]
    public void Should_reverse_list_recursive3()
    {
        var p = new LinkedList.Node("p");

        var head = LinkedList.ReverseListRecursive(p);

        Assert.Equal(p, head);
        Assert.Null(head.Next);
    }
}