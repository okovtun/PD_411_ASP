https://github.com/okovtun/PD_411_ASP.git
https://www.youtube.com/playlist?list=PLeqyOOqxeiIOomneIs-QvkQFqTkBUdJdo

HTML Standard:
https://html.spec.whatwg.org/multipage/

Appearance:
https://uiverse.io/elements
https://ant.design/components/divider

URL:
https://aspnet.github.io/quickgridsamples/columns/#:~:text=QuickGrid%20has%20two%20built%2Din,so%20you%20must%20specify%20it.

Blazor CSS:
https://stackoverflow.com/questions/77852983/blazor-quickgrid-column-width-how-to-set

Blazor Themes:
https://demos.blazorbootstrap.com/getting-started
https://docs.blazorbootstrap.com/getting-started/blazor-webapp-auto-global-net-8
https://demos.blazorbootstrap.com/theme-switcher

NavMenu:
https://blazor-university.com/routing/navigating-our-app-via-html/

TOREAD:
1. HTML-helpers;

TODO:
1. Как применить один CSS-файл к разным компонентам?

TODO:
1. На страницах 'StudentCreate' и 'StudentEdit' должндолжна быть возможность загрузки фото студента в Базу;
2. На страницах 'StudentDetails' и 'StudentEdit' должно отображаться фото студента, загруженное из Базы;
!!!	https://learn.microsoft.com/en-us/aspnet/core/blazor/file-uploads?view=aspnetcore-10.0	!!!

DONE:
1. При создании/редактировании группы направление обучения должно выбираться через выпадающий список [https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/input-components?view=aspnetcore-10.0];
2. При создании/редактировании группы учебные дни должны выбираться галочками;
3. Начало должно отображаться НЕ как дата, а как время [https://stackoverflow.com/questions/64052566/is-there-any-blazor-timepicker-and-colorpicker#:~:text=You%20can%20use%20the%20built%20in%20time%20picker%20like%20this%3A];
4. Проверить уникальность при добавлении/изменении направления;
5. Дни недели должны отображаться в таблице с группами словами, а не числом;
5. *Вынести дни недели в отдельный компонент, и встроить его в Create и Edit;

DONE:
1. В проекте 'Blazor\Movies' применить стороннюю тему (внешний вид);
2. В том же проекте обеспечить переключение тем - светлая/темная;
3. Запретить добавление дубликатов в таблицу 'Directions';			DONE

TODO:
1. В Solution 'Blazor' добавить проект 'Academy';
2. К проекту 'Academy' подключить нашу Базу 'PD_321';
3. В приложухе отобразить дисциплины, направления, группы, студентов и преподов;

DONE:
1. При добавлении/изменении киношки должна быть возможность загружать изображение;	DONE
2. Добавить brief(краткое описание);
3. Киношки в таблице должны отображаться в виде ссылок на Википедию, или другой внешний ресурс;
4. Из таблы убрать кнопку 'Delete'; DONE

DONE:
1. Скачать и установить Notepad++
	https://notepad-plus-plus.org/
2. Подгрузить SVG-значек прямо из SVG-файла;
3. Подгрузить в качестве иконки растровое изображение, например '*.png';

SVG:
https://stackoverflow.com/questions/10768451/inline-svg-in-css

DONE:
1. Напомнить про значки;
2. Задачи не должны повторяться;
3. В Solution 'Blazor' добавить проект 'Converter', и в этом проекте реализовать преобразование чисел:
	Dec2Bin;
	Dec2Hex;
	Bin2Dec;
	Hex2Dec;

	Bin2Hex;
	Hex2Bin;

DONE:
1. В проект 'Blazor' добавить компонент 'Power', который возводит число в степень;
2. В проект 'Blazor' добавить компонент 'Fibonacci', который выводит ряд Фибоначчи;
3. Для компонентов 'Power', 'Factorial' и 'Fibonacci' в NavMenu использовать свои значки;
4. *При вычислении Факториала и Фибоначчи ипользовать BigInteger;	DONE