package main

import "fmt"

func main() {
	// numbers := []int{2, 7, 11, 15} // output: [1,2]
	// target := 9
	// numbers := []int{2, 3, 4} // output: [1,3]
	// target := 6
	// numbers := []int{-1, 0} // output: [1,2]
	// target := -1

	numbers := []int{-4, -1, 0, 3, 5, 11} // output: [4,5]
	target := 8

	fmt.Println(twoSum(numbers, target))

	/*
		1--0--8
		...| /
		...5

		2--3
		| /
		4

		expected output: 2
	*/
	var graph = map[int][]int{
		0: {8, 1, 5},
		1: {0},
		5: {0, 8},
		8: {0, 5},
		2: {3, 4},
		3: {2, 4},
		4: {3, 2},
	}

	connectedComponentsCount(graph)
	connectedComponentsCountRecursive(graph)

	/*
		1--0--8
		...| /
		...5

		2--3
		| /
		4

		expected output: 4 (the largest "island")
	*/
	largestComponent(graph)

	/*
		3

		...8
		...|
		4--6--5
		...|
		...7

		1--2

		expected output: 5 (the largest "island")
	*/
	graph = map[int][]int{
		3: {},
		4: {'6'},
		6: {'4', '5', '7', '8'},
		8: {'6'},
		7: {'6'},
		5: {'6'},
		1: {'2'},
		2: {'1'},
	}
	largestComponent(graph)

	/*
		  w
		 / \
		x   \
		|    v
		y   /
		 \ /
		  z

		  expected output: 2 (the edge between w-v and v-z)
	*/
	edges := [][]string{
		{"w", "x"},
		{"x", "y"},
		{"z", "y"},
		{"z", "v"},
		{"w", "v"},
	}
	fmt.Printf("shortest path: %d\n", shortestPath(edges, "w", "z"))

	/*
		m
		|
		n
		|
		o --- t
		|
		p
		|
		q
		|
		r
		|
		s

		expected output: 6
	*/

	edges = [][]string{
		{"m", "n"},
		{"n", "o"},
		{"o", "p"},
		{"p", "q"},
		{"t", "o"},
		{"r", "q"},
		{"r", "s"},
	}
	fmt.Printf("shortest path: %d\n", shortestPath(edges, "m", "s"))

	matrix := [][]string{
		{"w", "l", "w", "w", "l", "w"},
		{"l", "l", "w", "w", "l", "w"},
		{"w", "l", "w", "w", "w", "w"},
		{"w", "w", "w", "l", "l", "w"},
		{"w", "l", "w", "l", "l", "w"},
		{"w", "w", "w", "w", "w", "w"},
	}
	fmt.Printf("island count: %d\n", islandCount(matrix)) //expected output: 4

	matrix = [][]string{
		{"w", "w"},
		{"w", "w"},
		{"w", "w"},
	}
	fmt.Printf("island count: %d\n", islandCount(matrix)) //expected output: 0

	matrix = [][]string{
		{"l", "l", "l"},
		{"l", "l", "l"},
		{"l", "l", "l"},
	}
	fmt.Printf("island count: %d\n", islandCount(matrix)) //expected output: 1

}
