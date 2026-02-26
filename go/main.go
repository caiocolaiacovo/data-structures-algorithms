package main

import (
	"fmt"
)

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
}
