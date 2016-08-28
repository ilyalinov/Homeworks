#include "AccelerometerWidget.h"
#include <QApplication>

int main(int argc, char *argv[])
{
	QApplication a(argc, argv);
	VectorSensorWidget w;
	w.show();

	return a.exec();
}
