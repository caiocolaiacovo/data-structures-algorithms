# DataStructures

A comprehensive study project exploring data structures and algorithms implementations in **C#** and **Go**.

## Overview

This repository contains implementations of fundamental data structures and algorithm problems from LeetCode, organized by programming language and topic.

## Project Structure

### C# (.NET 8)
Located in `dotnet/Dsa/`, this section includes:

#### Arrays & Strings
- **Binary Search** (`BinarySearch704.cs`) - O(log n) search implementation
- **Range Sum Query** (`RangeSumQuery303.cs`) - Prefix sum optimization

#### Binary Trees
- **Binary Trees** (`BinaryTree.cs`) - DFS/BFS traversals, tree operations
  - Depth-First Search (recursive and iterative)
  - Breadth-First Search
  - Tree sum, path sum, balance checking
- **Invert Binary Tree** (`InvertBinaryTree226.cs`) - Tree inversion algorithm
- **Binary Tree Inorder Traversal** (`BinaryTreeInorder94.cs`) - Inorder traversal [LeetCode 94](https://leetcode.com/problems/binary-tree-inorder-traversal/)
- **Maximum Depth of Binary Tree** (`MaximumDepthOfBinaryTree104.cs`) - Calculate tree depth [LeetCode 104](https://leetcode.com/problems/maximum-depth-of-binary-tree/)
- **Binary Tree Level Order Traversal** (`BinaryTreeLevelOrderTraversal102.cs`) - Level-order BFS traversal [LeetCode 102](https://leetcode.com/problems/binary-tree-level-order-traversal/)
- **Path Sum** (`PathSum112.cs`) - Check if root-to-leaf path equals target sum [LeetCode 112](https://leetcode.com/problems/path-sum/)

#### Graphs
- **Graph** (`Graph.cs`) - Graph data structure and island counting algorithm
- **Number of Islands** (`NumberOfIslands200.cs`) - Count connected components using DFS [LeetCode 200](https://leetcode.com/problems/number-of-islands/)
- **Clone Graph** (`CloneGraph133.cs`) - Deep copy of undirected graph [LeetCode 133](https://leetcode.com/problems/clone-graph/)
- **Longest Increasing Path in a Matrix** (`LongestIncreasingPathInAMatrix329.cs`) - Find longest increasing path [LeetCode 329](https://leetcode.com/problems/longest-increasing-path-in-a-matrix/)

#### Collections & Concurrency
- **Collections** (`Collections.cs`) - Comparison of .NET collections
  - List, Dictionary, HashSet, Stack, Queue
  - Thread-safe collections (ConcurrentDictionary, etc.)
- **Threading** (`Threads.cs`) - Concurrency patterns with locks

### Go
Located in `go/`, this section includes:

- **Two Pointers** (`twopointers167.go`) - Two-pointer technique for sorted arrays
- **Move Zeroes** (`movezeroes66.go`) - In-place array manipulation
- **Models** (`model/`) - Data structures for person, address, and purchase entities

## Getting Started

### Running C# Solutions
```bash
cd dotnet/Dsa
dotnet run
```

### Running Go Solutions
```bash
cd go
go run .
```