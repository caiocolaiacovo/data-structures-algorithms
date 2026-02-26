package main

// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/?envType=problem-list-v2&envId=two-pointers
// 167. Two Sum II - Input Array Is Sorted
func twoSum(numbers []int, target int) []int {
	left := 0
	right := len(numbers) - 1

	for {
		sum := numbers[left] + numbers[right]

		if sum == target {
			return []int{left + 1, right + 1}
		}

		if sum < target {
			left++
			continue
		}

		if sum > target {
			right--
			continue
		}
	}
}
