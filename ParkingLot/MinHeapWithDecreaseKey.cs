using System;
using System.Collections.Generic;

public class MinHeap<T>
    where T : IComparable<T>
{
    private List<T> heap;
    private Dictionary<T, int> indexMap;

    public MinHeap()
    {
        heap = new List<T>();
        indexMap = new Dictionary<T, int>();
    }

    public MinHeap(List<T> tList)
    {
        heap = new List<T>();
        indexMap = new Dictionary<T, int>();
        foreach (T element in tList)
        {
            Push(element);
        }
    }

    public int Count => heap.Count;

    public void Push(T item)
    {
        heap.Add(item);
        indexMap[item] = Count - 1;
        HeapifyUp(Count - 1);
    }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        T min = heap[0];
        indexMap.Remove(min);
        heap[0] = heap[Count - 1];
        indexMap[heap[0]] = 0;
        heap.RemoveAt(Count - 1);
        HeapifyDown(0);

        return min;
    }

    public void DecreaseKey(T item)
    {
        if (!indexMap.ContainsKey(item))
        {
            throw new KeyNotFoundException("Item not found in the heap");
        }

        int index = indexMap[item];
        HeapifyUp(index);
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (heap[index].CompareTo(heap[parentIndex]) >= 0)
            {
                break;
            }

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;
        int smallest = index;

        if (leftChild < Count && heap[leftChild].CompareTo(heap[smallest]) < 0)
        {
            smallest = leftChild;
        }

        if (rightChild < Count && heap[rightChild].CompareTo(heap[smallest]) < 0)
        {
            smallest = rightChild;
        }

        if (smallest != index)
        {
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }

    private void Swap(int a, int b)
    {
        T temp = heap[a];
        heap[a] = heap[b];
        heap[b] = temp;

        indexMap[heap[a]] = a;
        indexMap[heap[b]] = b;
    }
}