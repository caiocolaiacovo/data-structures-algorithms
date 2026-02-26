package main

// https://leetcode.com/problems/move-zeroes/solutions/127441/move-zeroes-by-leetcode-yszs/
// 283. Move Zeroes
func moveZeroes(nums []int) {
	i := 0
	for j := range nums {
		if nums[j] != 0 {
			// troca i com j
			oldi := nums[i]
			nums[i] = nums[j]
			nums[j] = oldi

			// incrementa i
			i++
		}
	}
}

/**

    i
1,3,0,0,12
        j

**/
