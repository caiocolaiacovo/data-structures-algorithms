package main

import (
	"fmt"
	"unsafe"
)

/*
1--0--8
...| /
...5

2--3
| /
4

expected output: 2
*/
// n = # of nodes
// e = # of edges
// time complexity: O(n + e), the outer loop iterates over all nodes O(n), and each edge is traversed
// exacly once when processing neighbors
// space complexity: O(n) in worst case when a graph is a line, all nodes will be pushed into the stack
func connectedComponentsCount(graph map[int][]int) {
	visited := map[int]struct{}{}
	fmt.Printf("visited pointer: %p\n", unsafe.Pointer(&visited))
	count := 0

	for k := range graph {
		_, wasVisited := visited[k]

		if wasVisited {
			continue
		}

		dfs(graph, k, visited)
		count++
	}

	fmt.Printf("total count: %d\n", count)
}

func dfs(graph map[int][]int, current int, visited map[int]struct{}) {
	fmt.Printf("visited pointer: %p\n", unsafe.Pointer(&visited))
	stack := []int{}
	stack = append(stack, current)

	for {
		if len(stack) == 0 {
			break
		}
		current = stack[len(stack)-1]
		stack = stack[:len(stack)-1] //pop

		_, wasVisited := visited[current]

		if wasVisited == true {
			continue
		}

		visited[current] = struct{}{}

		for _, n := range graph[current] {
			stack = append(stack, n)
		}
	}
}

// time and space complexity: same as connectedComponentsCount() above
func connectedComponentsCountRecursive(graph map[int][]int) {
	visited := map[int]struct{}{}
	count := 0

	for node := range graph {
		endedGroup := dfsRecursive(graph, node, visited)

		if endedGroup {
			count++
		}
	}

	fmt.Printf("total count: %d\n", count)
}

func dfsRecursive(graph map[int][]int, node int, visited map[int]struct{}) bool {
	if _, wasVisited := visited[node]; wasVisited == true {
		return false
	}

	visited[node] = struct{}{}

	for _, n := range graph[node] {
		dfsRecursive(graph, n, visited)
	}

	return true
}

func largestComponent(graph map[int][]int) {
	visited := make(map[int]struct{})
	largest := -1

	for k := range graph {
		count := dfsCount(graph, k, visited)

		if count > largest {
			largest = count
		}
	}

	fmt.Printf("largest count: %d\n", largest)
}

func dfsCount(graph map[int][]int, node int, visited map[int]struct{}) int {
	if _, wasVisited := visited[node]; wasVisited == true {
		return 0
	}

	visited[node] = struct{}{}
	count := 1

	for _, n := range graph[node] {
		count += dfsCount(graph, n, visited)
	}

	return count
}

// BFS is the best option here (since DFS can eventualy find the target but can potencially run thru all nodes)
func shortestPath(edges [][]string, source string, dest string) int {
	graph := createGraphFromEdges(edges)
	visited := map[string]struct{}{}

	queue := []struct {
		node     string
		distance int
	}{}
	queue = append(queue, struct {
		node     string
		distance int
	}{node: source, distance: 0}) //enqueue

	for {
		if len(queue) == 0 {
			break
		}

		current := queue[0]
		queue = queue[1:] //dequeue

		if current.node == dest {
			return current.distance
		}

		visited[current.node] = struct{}{}

		for _, neighbour := range graph[current.node] {
			if _, wasVisited := visited[neighbour]; wasVisited == false {
				queue = append(queue, struct {
					node     string
					distance int
				}{node: neighbour, distance: current.distance + 1})
			}
		}
	}

	return -1
}

func createGraphFromEdges(edges [][]string) map[string][]string {
	//convert to a map
	graph := make(map[string][]string)

	for _, e := range edges {
		a := e[0]
		b := e[1]

		if _, exists := graph[a]; exists == false {
			graph[a] = []string{}
		}
		if _, exists := graph[b]; exists == false {
			graph[b] = []string{}
		}

		graph[a] = append(graph[a], b)
		graph[b] = append(graph[b], a)
	}

	return graph
}
