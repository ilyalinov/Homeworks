#include <iostream>

using namespace std;

struct QueueElement
{
	int priority = -1;
	int vertice = 0;
	QueueElement *next = nullptr;
};

struct Queue
{
	QueueElement *head = nullptr;
};

Queue* createQueue()
{
	return new Queue();
}

QueueElement* createElement(int vertice, int priority)
{
	QueueElement *newElement = new QueueElement();
	newElement->vertice = vertice;
	newElement->priority = priority;
	return newElement;
}

void addElement(Queue *queue, QueueElement *queueElement)
{
	if (queue->head == nullptr)
	{
		queue->head = queueElement;
	}
	else
	{
		QueueElement *temp = queue->head;
		queue->head = queueElement;
		queue->head->next = temp;
	}
}

void deleteVertice(Queue *queue, int vertice)
{
	QueueElement *temp = queue->head;
	QueueElement *temp1 = queue->head;
	while (temp != nullptr)
	{
		if (temp->vertice == vertice)
		{
			break;
		}
		temp1 = temp;
		temp = temp->next;
	}
	if (temp == temp1)
	{
		queue->head = queue->head->next;
		delete temp;
	}
	else
	{
		temp1->next = temp->next;
		delete temp;
	}
}

int extractMin(Queue *queue)
{
	QueueElement *temp = queue->head;
	int minimumPriority = -1;
	int vertice = -1;
	while (temp != nullptr)
	{
		if (temp->priority != -1)
		{
			if (minimumPriority == -1)
			{
				vertice = temp->vertice;
				minimumPriority = temp->priority;
			}
			else if (temp->priority < minimumPriority)
			{
				vertice = temp->vertice;
				minimumPriority = temp->priority;
			}
		}
		temp = temp->next;
	}
	deleteVertice(queue, vertice);
	return vertice;
}

void deleteQueue(Queue *queue)
{
	while (queue->head != nullptr)
	{
		QueueElement *temp = queue->head;
		queue->head = queue->head->next;
		delete temp;
	}
	delete queue;
}

bool isEmpty(Queue *queue)
{
	return (queue->head == nullptr);
}

int priority(Queue *queue, int vertice)
{
	QueueElement *temp = queue->head;
	while (temp != nullptr)
	{
		if (temp->vertice == vertice)
		{
			return temp->priority;
		}
		temp = temp->next;
	}
	return 0;
}

void setPriority(Queue *queue, int vertice, int number)
{
	QueueElement *temp = queue->head;
	while (temp != nullptr)
	{
		if (temp->vertice == vertice)
		{
			temp->priority = number;
			return;
		}
		temp = temp->next;
	}
}