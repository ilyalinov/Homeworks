#include "AccelerometerWidget.h"
#include <QTime>

VectorSensorWidget::VectorSensorWidget(QWidget *parent)
	: QWidget(parent)
	, mInterval(500)
	, isFirstIteration(true)
	, time(0)
	, axisMargin(10)
{
	this->setFixedSize(width(), height());

	QTime now = QTime::currentTime();
	qsrand(now.msec());

	mTimer.setInterval(mInterval);
	connect(&mTimer, SIGNAL(timeout()), this, SLOT(update()));

	mTimer.start();
}

void VectorSensorWidget::paintEvent(QPaintEvent *)
{
	QPen bluePen(Qt::blue, 2, Qt::SolidLine);
	QPen redPen(Qt::red, 2, Qt::SolidLine);
	QPen greenPen(Qt::green, 2, Qt::SolidLine);

	renew();

	QPainter painter(this);
	painter.save();
	painter.setRenderHint(QPainter::Antialiasing);

	setMatrix(painter);
	drawAxis(painter);
	painter.restore();
	drawAxisXName(painter);
	painter.setRenderHint(QPainter::Antialiasing);
	setMatrix(painter);
	markTimeAxis(painter);

	// Paint OX readings
	drawDiagram(painter, pointsX, redPen);
	// Paint OY readings
	drawDiagram(painter, pointsY, bluePen);
	// Paint OZ readings
	drawDiagram(painter, pointsZ, greenPen);
}

void VectorSensorWidget::delay(int millisecondsToWait)
{
	QTime dieTime = QTime::currentTime().addMSecs( millisecondsToWait );
	while(QTime::currentTime() < dieTime)
	{
		QCoreApplication::processEvents(QEventLoop::AllEvents, 100);
	}
}

void VectorSensorWidget::setMatrix(QPainter &painter)
{
	const qreal x0 = static_cast<qreal>(axisMargin);
	const qreal y0 = height() / 2;

	QMatrix m;
	m.translate(x0, y0);
	// Scale to flip y axis
	m.scale(1.0, -1.0);

	painter.setMatrix(m);
}

void VectorSensorWidget::drawAxis(QPainter &painter)
{
	QPen blackPen(Qt::black, 2, Qt::SolidLine);
	painter.setPen(blackPen);
	//Draw x axis
	painter.drawLine(0 - axisMargin, 0, width() - 2 * axisMargin, 0);
	// Draw y axis
	painter.drawLine(0, 0 - (height() / 2), 0, height() / 2);
	// Draw direction arrows
	painter.setBrush(Qt::black);
	QPolygonF xArrow;
	xArrow << QPointF(width() - (2 * axisMargin), 0)
		  << QPointF(width() - (3 * axisMargin), axisMargin / 2)
		  << QPointF(width() - (3 * axisMargin), 0 - (axisMargin / 2));
	painter.drawPolygon(xArrow);

	QPolygonF yArrow;
	yArrow << QPointF(0, height() / 2)
		  << QPointF(axisMargin / 2, height() / 2 - axisMargin)
		  << QPointF(0 - (axisMargin / 2), height() / 2 - axisMargin);
	painter.drawPolygon(yArrow);
}

void VectorSensorWidget::drawAxisXName(QPainter &painter)
{
	QString name = "time, sec";
	QPointF position(width() - 3 * axisMargin, height() / 2 + 2 * axisMargin);
	const int size = 100;
	QRect rect = QRect(position.x() - size / 2, position.y() - size / 2, size, size);
	QFont font = QFont("times");
	font.setPixelSize(12);
	painter.setFont(font);
	painter.drawText(rect, Qt::AlignCenter, name);
}

void VectorSensorWidget::drawDiagram(QPainter &painter, QVector<QPointF> points, QPen pen)
{
	painter.setPen(pen);
	int i = 0;
	for (i = 0; i < points.size() - 1; i++)
	{
		painter.drawLine(points[i], points[i + 1]);
	}
}

void VectorSensorWidget::renew()
{
	int randomNumberX = qrand() % height() - (height() / 2);
	int randomNumberY = qrand() % height() - (height() / 2);
	int randomNumberZ = qrand() % height() - (height() / 2);
	QPointF newPointX = QPointF(xCoordinate(), randomNumberX);
	QPointF newPointY = QPointF(xCoordinate(), randomNumberY);
	QPointF newPointZ = QPointF(xCoordinate(), randomNumberZ);

	updateReadings(pointsX, newPointX);
	updateReadings(pointsY, newPointY);
	updateReadings(pointsZ, newPointZ);

	if (time <= 20)
		time++;
}

void VectorSensorWidget::updateReadings(QVector<QPointF> &points, QPointF newPoint)
{
	if (time > 20)
	{
		for (int i = 0; i < points.size() - 1; i++)
		{
			points[i] = points[i + 1];
			qreal curX = points[i].x();
			qreal shift = (width() - axisMargin) / 20;
			points[i].setX(curX - shift);
		}
		points[points.size() - 1] = newPoint;
	}
	else
	{
		points.append(newPoint);
	}
}

void VectorSensorWidget::markTimeAxis(QPainter &painter)
{
	painter.save();
	// flip y axis back
	painter.scale(1, -1);
	const int pixelSize = 6;
	const int margin = 3;
	QFont font = QFont("times");
	font.setPixelSize(pixelSize);

	qreal time = 0;
	const qreal timeShift = 0.5;
	QPointF textPosition = QPointF(0, 0 + 3 * margin);
	for (int i = 0; i < 20; i++)
	{
		painter.drawLine(textPosition.x(), margin, textPosition.x(), 0 - margin);
		const int size = 100;
		QRect rect = QRect(textPosition.x() - size / 2, textPosition.y() - size / 2, size, size);
		painter.drawText(rect, Qt::AlignCenter, QString::number(time));
		textPosition.setX(textPosition.x() + (width() - 2 * axisMargin) / 20);
		time = time + timeShift;
	}
	painter.restore();
}

qreal VectorSensorWidget::xCoordinate()
{
	if (time > 20)
	{
		return width() - (2 * axisMargin);
	}
	return (width() - 2 * axisMargin) / 20 * time;
}
