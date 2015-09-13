#pragma once

// Queue elements strucutre
struct QueueElement;

// Queue strucuture
struct Queue;

// Creates null queue and returns it
Queue* createQueue();

// Creates queue element by vertice and priority
QueueElement* createElement(int vertice, int priority);

// Adds element to the queueu
void addElement(Queue *queue, QueueElement *queueElement);

// Deletes one vertice from the queue 
void deleteVertice(Queue *queue, int vertice);

// Finds vertice with minimum priority and returns it
int extractMin(Queue *queue);

// Deletes whole queue
void deleteQueue(Queue *queue);

// Checks the queue if it's empty or not
bool isEmpty(Queue *queue);

// Returns priority by given vertice
int priority(Queue *queue, int vertice);

// Sets priority to the given vertice
void setPriority(Queue *queue, int vertice, int number);