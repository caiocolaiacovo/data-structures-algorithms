# DataStructures

A comprehensive study project exploring data structures and algorithms implementations in **C#** and **Go**.

## Overview

This repository contains implementations of fundamental data structures and algorithm problems from LeetCode, organized by programming language and topic.

## Project Structure

### C# (.NET 8)
Located in `dotnet/Dsa/`, this section includes:

- **Binary Search** (`BinarySearch704.cs`) - O(log n) search implementation
- **Binary Trees** (`BinaryTree.cs`) - DFS/BFS traversals, tree operations
  - Depth-First Search (recursive and iterative)
  - Breadth-First Search
  - Tree sum, path sum, balance checking
- **Invert Binary Tree** (`InvertBinaryTree226.cs`) - Tree inversion algorithm
- **Range Sum Query** (`RangeSumQuery303.cs`) - Prefix sum optimization
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