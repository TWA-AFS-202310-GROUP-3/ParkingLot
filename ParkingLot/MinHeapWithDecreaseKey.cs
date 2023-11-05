using System;
using System.Collections.Generic;

public class MinHeap<T>
    where T : IComparable<T>
{
    private List<T> heap;
    private Dictionary<T, int> elementIndices;

    public MinHeap()
    {
        heap = new List<T>();
        elementIndices = new Dictionary<T, int>();
    }

    public MinHeap(List<T> tList)
    {
        heap = new List<T>();
        elementIndices = new Dictionary<T, int>();
        foreach (T element in tList)
        {
            Push(element);
        }
    }

    public int Count => heap.Count;

    public void Push(T item)
    {
        heap.Add(item);
        elementIndices[item] = Count - 1;
        HeapifyUp(Count - 1);
    }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        T min = heap[0];
        RemoveElement(min);
        return min;
    }

    public void DecreaseKey(T element)
    {
        if (!elementIndices.ContainsKey(element))
        {
            throw new ArgumentException("Element not found in the heap");
        }

        int index = elementIndices[element];
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

    private void Swap(int a, int b)
    {
        T temp = heap[a];
        heap[a] = heap[b];
        heap[b] = temp;
        elementIndices[heap[a]] = a;
        elementIndices[heap[b]] = b;
    }

    private void RemoveElement(T element)
    {
        if (!elementIndices.ContainsKey(element))
        {
            return;
        }

        int indexToRemove = elementIndices[element];
        int lastIndex = Count - 1;
        if (indexToRemove != lastIndex)
        {
            Swap(indexToRemove, lastIndex);
        }

        heap.RemoveAt(lastIndex);
        elementIndices.Remove(element);
        if (indexToRemove < lastIndex)
        {
            HeapifyUp(indexToRemove);
        }
    }
}
