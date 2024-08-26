--CLASE 15/08/2024

--1. Se necesita saber a qué cliente se les vendió y qué vendedor realizó la venta
--en qué fecha y cuál fue el número de factura de los años 2010, 2017, 2018 y
--2022. 
select c.cod_cliente,c.nom_cliente + c.ape_cliente 'Cliente', v.nom_vendedor + v.ape_vendedor 'Vendedor',
       f.fecha 'fecha', f.nro_factura
from facturas f, clientes c, vendedores v
where f.cod_cliente = c.cod_cliente
and f.cod_vendedor = v.cod_vendedor
and YEAR(f.fecha) in (2010,2017,2018,2022)

--2. Emitir un reporte con los datos de todos los vendedores Si el vendedor ha
--tenido ventas en lo que va del año, muestre, además, el número de factura y
--la fecha de esas ventas.
select v.nom_vendedor + v.ape_vendedor 'Vendedor', 
       f.nro_factura, f.fecha 'Fecha'
from facturas f, vendedores v
where f.cod_vendedor = v.cod_vendedor
and DATEDIFF(year, f.fecha,getdate())=0

--3. Generar un listado con los datos de las facturas incluidos los del vendedor y
--cliente) y de las ventas de esas facturas, incluido el importe; para las ventas
--de febrero y marzo de los años 2016 y 2020 y siempre que el artículo empiece
--con letras que van de la “a” a la “m”. Mostrar la fecha de la factura en orden
--día, mes y año, sin la hora.
select c.nom_cliente 'cliente', v.nom_vendedor 'vendedor',MONTH(f.fecha), YEAR(f.fecha), df.pre_unitario * df.cantidad 'Importe'
from facturas f, clientes c, vendedores v, detalle_facturas df, articulos a
where f.cod_cliente = c.cod_cliente
and f.cod_vendedor = v.cod_vendedor
and f.nro_factura = df.nro_factura
and df.cod_articulo = a.cod_articulo
and month(f.fecha) in (2,3)
and YEAR(f.fecha) in (2016,2020)
and a.descripcion like'[a-m]%'

--Queremos analizar el rendimiento de ventas de nuestros productos y determinar cuáles son los 5 productos 
--con mayores ventas totales en términos de cantidad.
select top 5 SUM(df.cantidad), descripcion 'producto', max(f.fecha)
from facturas f,articulos a, detalle_facturas df
where a.cod_articulo = df.cod_articulo
and f.nro_factura = df.nro_factura
group by descripcion
order by 1 desc

--Queremos identificar al cliente que ha realizado la mayor cantidad de compras en el año en curso.
select top 1 SUM(df.cantidad), c.nom_cliente + ' ' + c.ape_cliente 'cliente'
from clientes c, facturas f, detalle_facturas df
where c.cod_cliente = f.cod_cliente
and f.nro_factura = df.nro_factura
and YEAR(fecha) = YEAR(getdate())
group by c.nom_cliente + ' ' + c.ape_cliente 
order by 1 desc

--CLASE 22/08/2024

--1) Calcular el total facturado por cada vendedor y a cada cliente el año pasado 
--ordenando por vendedor primero y luego por cliente.

SELECT v.nom_vendedor + ' ' + v.ape_vendedor 'Vendedor',
       c.nom_cliente + ' ' + c.ape_cliente 'Cliente', 
       SUM(df.cantidad * pre_unitario) 'Facturado'
FROM vendedores v, facturas f, clientes c, detalle_facturas df
WHERE f.cod_cliente = c.cod_cliente
AND f.cod_vendedor = v.cod_vendedor
AND f.nro_factura = df.nro_factura
AND DATEDIFF(YEAR,f.fecha,GETDATE())=1
GROUP BY v.ape_vendedor,v.nom_vendedor, c.ape_cliente,c.nom_cliente
ORDER BY 1,2

--2) Se necesita un listado que informe sobre el monto maximo, minimo y total que gasto 
--en esta libreria cada cliente el año pasado, pero solo el importe gastado por esos 
--clientes entre 50 y 90

SELECT c.cod_cliente, c.nom_cliente + ' ' + c.ape_cliente 'Cliente',
       MAX(pre_unitario) 'Monto maximo',
	   MIN(pre_unitario)'Monto minimo',
	   SUM(df.cantidad * pre_unitario)'Total'
FROM facturas f, detalle_facturas df, clientes c
WHERE f.nro_factura = df.nro_factura 
AND f.cod_cliente = c.cod_cliente
AND DATEDIFF(YEAR,f.fecha,GETDATE())=1
GROUP BY c.cod_cliente, c.nom_cliente, c.ape_cliente
HAVING SUM(df.cantidad * pre_unitario) BETWEEN 50000 AND 90000

--3) Desde la administracion se solicita un reporte que muestre el precio
--promedio, el importe total y el promedio del importe vendido por 
--articulo que no comience 'c', y que ese importe total vendido sea superior a 20000.
--Redondea el importe para arriba  y los promedios para abajo

SELECT a.cod_articulo, a.descripcion 'Articulo',  
       FLOOR(AVG(a.pre_unitario))'Precio Promedio',
	   CEILING(SUM(df.cantidad * df.pre_unitario)) 'Importe Total',
       FLOOR(AVG(df.cantidad * a.pre_unitario)) 'Prom. Importe' 
FROM detalle_facturas df, articulos a
WHERE df.cod_articulo = a.cod_articulo
AND a.descripcion NOT LIKE 'C%'
GROUP BY a.cod_articulo, a.descripcion
HAVING SUM(df.cantidad * df.pre_unitario) > 20000

--4) Calcular el total facturado por cada vendedor y a cada cliente
--, por vendedor primero y luego por cliente, ademas mostrar nombre del dia de la venta
--acompañado del año que se realizo, ordenarlo por dia semanal

SELECT v.nom_vendedor + ' ' + v.ape_vendedor 'Vendedor', c.nom_cliente + ' ' + c.ape_cliente 'Cliente',
		SUM(df.cantidad * df.pre_unitario)'Total', DATENAME(weekday,f.fecha) 'Dia',DATEPART(year,f.fecha)'Año'
FROM facturas f,detalle_facturas df, vendedores v, clientes c
WHERE f.nro_factura = df.nro_factura 
AND f.cod_cliente = c.cod_cliente 
AND f.cod_vendedor = v.cod_vendedor
GROUP BY v.nom_vendedor,v.ape_vendedor,c.nom_cliente,c.ape_cliente,f.fecha
ORDER BY fecha asc