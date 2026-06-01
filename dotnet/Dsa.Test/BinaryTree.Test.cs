namespace Dsa.Test;

public class BinaryTreeTest
{
    [Fact]
    public void Should_traverse_dfs_pre_order()
    {
        /*
            a
           / \
          b   c
         / \   \
        d   e   f
           /
          g
        */
        var a = new Node("a");
        var b = new Node("b");
        var c = new Node("c");
        var d = new Node("d");
        var e = new Node("e");
        var f = new Node("f");
        var g = new Node("g");
        a.Left = b;
        a.Right = c;
        b.Left = d;
        b.Right = e;
        c.Right = f;
        e.Left = g;
        var expected = "a,b,d,e,g,c,f";

        var outputRecursive = BinaryTree.DFSRecursivePreOrder(a);
        var outputStack = BinaryTree.DFSStackPreOrder(a);

        Assert.Equal(expected, outputRecursive);
        Assert.Equal(expected, outputStack);
    }

    [Fact]
    public void Should_traverse_dfs_post_order()
    {
        /*
            a
           / \
          b   c
             / \
            d   e
               / \
              f   g
        */
        var a = new Node("a");
        var b = new Node("b");
        var c = new Node("c");
        var d = new Node("d");
        var e = new Node("e");
        var f = new Node("f");
        var g = new Node("g");
        a.Left = b;
        a.Right = c;
        c.Left = d;
        c.Right = e;
        e.Left = f;
        e.Right = g;
        var expected = "b,d,f,g,e,c,a";

        var outputRecursive = BinaryTree.DFSRecursivePostOrder(a);

        Assert.Equal(expected, outputRecursive);
    }

    [Fact]
    public void Should_traverse_dfs_in_order()
    {
        /*
             10
           /   \
          7     12
           \   /  \
           9  11   25
                  /  \
                24    99
        */
        var a = new Node(10);
        var b = new Node(7);
        var c = new Node(12);
        var d = new Node(9);
        var e = new Node(11);
        var f = new Node(25);
        var g = new Node(24);
        var h = new Node(99);
        a.Left = b;
        a.Right = c;
        b.Right = d;
        c.Left = e;
        c.Right = f;
        f.Left = g;
        f.Right = h;
        var expected = "7,9,10,11,12,24,25,99";

        var outputRecursive = BinaryTree.DFSRecursiveInOrder(a);

        Assert.Equal(expected, outputRecursive);
    }

    [Fact]
    public void Should_traverse_bfs()
    {
        var a = new Node("a");
        var b = new Node("b");
        var c = new Node("c");
        var d = new Node("d");
        var e = new Node("e");
        var f = new Node("f");
        var g = new Node("g");
        a.Left = b;
        a.Right = c;
        b.Left = d;
        b.Right = e;
        c.Right = f;
        e.Left = g;
        var expected = "a,b,c,d,e,f,g";

        var outputRecursive = BinaryTree.BreadthFirstValues(a);

        Assert.Equal(expected, outputRecursive);
    }
}