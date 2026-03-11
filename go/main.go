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

		expected output: 4 (the biggest "island")
	*/
}
