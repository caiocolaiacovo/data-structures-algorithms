# Data Structures & Algorithms

A comprehensive study project exploring data structures and algorithms implementations in **C#** and **Go**.

## Overview

This repository contains implementations of fundamental data structures and algorithm problems from LeetCode, organized by programming language and topic.

## Project Structure

### C# (.NET 8)
Located in `dotnet/Dsa/`, this section includes:

#### Arrays & Strings
- **Binary Search** (`BinarySearch704.cs`) - Search implementation [LeetCode 704](https://leetcode.com/problems/binary-search/)
- **Search Insert Position** (`SearchInsertPosition35.cs`) - Binary search variant to find insert position [LeetCode 35](https://leetcode.com/problems/search-insert-position/)
- **Find Peak Element** (`FindPeakElement162.cs`) - Find an element greater than its neighbors [LeetCode 162](https://leetcode.com/problems/find-peak-element/)
- **Range Sum Query** (`RangeSumQuery303.cs`) - Prefix sum optimization [LeetCode 303](https://leetcode.com/problems/range-sum-query-immutable/)

#### Binary Trees
- **Binary Trees** (`BinaryTree.cs`) - DFS/BFS traversals, tree operations
  - Depth-First Search (recursive and iterative)
  - Breadth-First Search
  - Tree sum, path sum, balance checking
- **Invert Binary Tree** (`InvertBinaryTree226.cs`) - Tree inversion algorithm [LeetCode 226](https://leetcode.com/problems/invert-binary-tree/)
- **Binary Tree Inorder Traversal** (`BinaryTreeInorder94.cs`) - Inorder traversal [LeetCode 94](https://leetcode.com/problems/binary-tree-inorder-traversal/)
- **Maximum Depth of Binary Tree** (`MaximumDepthOfBinaryTree104.cs`) - Calculate tree depth [LeetCode 104](https://leetcode.com/problems/maximum-depth-of-binary-tree/)
- **Binary Tree Level Order Traversal** (`BinaryTreeLevelOrderTraversal102.cs`) - Level-order BFS traversal [LeetCode 102](https://leetcode.com/problems/binary-tree-level-order-traversal/)
- **Path Sum** (`PathSum112.cs`) - Check if root-to-leaf path equals target sum [LeetCode 112](https://leetcode.com/problems/path-sum/)

#### Graphs
- **Graph** (`Graph.cs`) - Graph data structure with DFS/BFS traversals and path finding
- **Number of Islands** (`NumberOfIslands200.cs`) - Count connected components using DFS [LeetCode 200](https://leetcode.com/problems/number-of-islands/)
- **Clone Graph** (`CloneGraph133.cs`) - Deep copy of undirected graph using BFS [LeetCode 133](https://leetcode.com/problems/clone-graph/)
- **Longest Increasing Path in a Matrix** (`LongestIncreasingPathInAMatrix329.cs`) - DFS with memoization [LeetCode 329](https://leetcode.com/problems/longest-increasing-path-in-a-matrix/)

#### Linked Lists
- **Linked List** (`LinkedList.cs`) - Singly linked list operations
  - Print all values (iterative and recursive)
  - Zipper two lists (interleave nodes)
  - Sum of values (iterative and recursive)
  - Reverse list (iterative and recursive)
  - Cycle detection (HashSet approach and Floyd's fast/slow pointer)

#### Backtracking
- **Backtracking** (`Backtracking.cs`) - Generate all possible strings of length n from a set of letters
- **Letter Combinations of a Phone Number** (`LetterCombinationsPhoneNumber17.cs`) - All letter combinations from phone keypad digits [LeetCode 17](https://leetcode.com/problems/letter-combinations-of-a-phone-number/)

#### Dynamic Programming
- **Fibonacci** (`FibonacciDp.cs`) - Fibonacci number calculation
  - Naive recursive
  - Memoized
- **Count Paths** (`CountPathsDp.cs`) - Count all paths from top-left to bottom-right in a grid with obstacles, using memoization

#### Codility
- **Arr List Len** (`CodilityArrListLen.cs`) - Find the length of a linked list encoded as an array [Codility Training 7](https://app.codility.com/programmers/trainings/7/arr_list_len/)
- **Count Bounded Slices** (`CodilityCountBoundedSlices.cs`) - Count slices where max−min ≤ K [Codility Training 7](https://app.codility.com/programmers/trainings/7/count_bounded_slices/)

#### Collections & Concurrency
- **Collections** (`Collections.cs`) - Comparison of .NET collections
  - LinkedList, List, Dictionary, HashSet, Stack, Queue
  - Sorted collections (SortedDictionary, SortedSet)
  - Ordered collections (OrderedDictionary)
  - Thread-safe collections (ConcurrentDictionary, BlockingCollection)
  - PriorityQueue

### Go
Located in `go/`, this section includes:

- **Graph Algorithms** (`graph.go`) - Connected components (DFS iterative/recursive), largest component, shortest path (BFS), island counting, minimum island size
- **Two Pointers** (`twopointers167.go`) - Two-pointer technique for sorted arrays [LeetCode 167](https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/)
- **Move Zeroes** (`movezeroes66.go`) - In-place array manipulation [LeetCode 283](https://leetcode.com/problems/move-zeroes/)
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
