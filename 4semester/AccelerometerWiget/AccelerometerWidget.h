#ifndef ACCELEROMETERWIDGET_H
#define ACCELEROMETERWIDGET_H

#include <QTWidgets>
#include <QVector>
#include <QTimer>
#include <QPen>
#include <QtGlobal>

class VectorSensorWidget : public QWidget
{
	Q_OBJECT
public:
	VectorSensorWidget(QWidget *parent = 0);

protected:
	void paintEvent(QPaintEvent *);

private:
	void delay(int millisecondsToWait);
	void renew();
	void drawDiagram(QPainter &painter, QVector<QPointF> points, QPen pen);
	void drawAxis(QPainter &painter);
	void drawAxisXName(QPainter & painter);
	void setMatrix(QPainter &painter);
	void updateReadings(QVector<QPointF> &points, QPointF newPoint);
	void markTimeAxis(QPainter &painter);
	qreal xCoordinate();

	QVector<QPointF> pointsX;
	QVector<QPointF> pointsY;
	QVector<QPointF> pointsZ;
	QVBoxLayout layout;
	const int mInterval;
	QTimer mTimer;
	bool isFirstIteration;
	qreal time;
	const int axisMargin;
};

#endif // ACCELEROMETERWIDGET_H
