# Beta.Data.MyCat
基于mysql.data 改造的适用于MyCat的组件



因为mycat支持sqlserver、mysql、pgsql、oracle数据库，而mysql.data组件只支持mysql数据库，所以为了支持多库Beta.Data.MyCat组件在原有链接字符串的基础上加了“dbtype=xxx”,用来识别应用程序具体链接的数据库类型。该参数为必选项，可选值为：sqlserver、mysql、pgsql、oracle。

Beta.Data.MyCat 组件是在mysql.data组件的基础上改的，里面**百分之九十九点九**都是mysql.data的源码，我这里只做了简单的修改。这里要重点强调一下。

为了避免命名空间上与mysql.data 组件冲突，所以把命名空间改了一下。

使用方法：

定义链接字符串：

```c#
string con = "dbtype=sqlserver;server=xxxx;Port=8066;uid=root;pwd=xxxxx;database=xxxx;sslmode=none;Charset=utf8mb4;pooling=true;keepalive=1";
```

其他的使用方法与mysql.data组件没有任何差别，与Dapper结合使用更佳。

后面再看看能不能跟EfCore结合。