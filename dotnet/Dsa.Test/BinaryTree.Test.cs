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
}