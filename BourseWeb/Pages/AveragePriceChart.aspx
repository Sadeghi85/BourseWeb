<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AveragePriceChart.aspx.cs" Inherits="BourseWeb.Pages.AveragePriceChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <script src="/Scripts/lightweight-charts.standalone.production.js"></script>

    



</head>
<body>
    <form id="form1" runat="server">
        <style>
            @font-face {
                font-family: 'WYekan';
                src: url('/Fonts/web_Yekan.woff') format('woff');
                font-weight: normal;
                font-style: normal;
            }

            body {
                font-family: 'IRANSans','WYekan', tahoma, verdana;
            }

        </style>


        <script>
            g_days_in_month = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            j_days_in_month = [31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29];
            function div(n, t) {
                return Math.floor(n / t)
            }
            function remainder(n, t) {
                return n - div(n, t) * t
            }
            function gregorian_to_jalali(n) {
                var r, f, o, e, s, h, u, t, c, i;
                for (r = n[0] - 1600,
                f = n[1] - 1,
                o = n[2] - 1,
                u = 365 * r + div(r + 3, 4) - div(r + 99, 100) + div(r + 399, 400),
                i = 0; i < f; ++i)
                    u += g_days_in_month[i];
                for (f > 1 && (r % 4 == 0 && r % 100 != 0 || r % 400 == 0) && ++u,
                u += o,
                t = u - 79,
                c = div(t, 12053),
                t = remainder(t, 12053),
                e = 979 + 33 * c + 4 * div(t, 1461),
                t = remainder(t, 1461),
                t >= 366 && (e += div(t - 1, 365),
                t = remainder(t - 1, 365)),
                i = 0; i < 11 && t >= j_days_in_month[i]; ++i)
                    t -= j_days_in_month[i];
                return s = i + 1,
                h = t + 1,
                [e, s, h]
            }
            function jalali_to_gregorian(n) {
                var r, o, s, f, h, c, t, e, u, i;
                for (f = n[0] - 979,
                h = n[1] - 1,
                c = n[2] - 1,
                e = 365 * f + div(f, 33) * 8 + div(remainder(f, 33) + 3, 4),
                i = 0; i < h; ++i)
                    e += j_days_in_month[i];
                for (e += c,
                t = e + 79,
                r = 1600 + 400 * div(t, 146097),
                t = remainder(t, 146097),
                u = 1,
                t >= 36525 && (t--,
                r += 100 * div(t, 36524),
                t = remainder(t, 36524),
                t >= 365 ? t++ : u = 0),
                r += 4 * div(t, 1461),
                t = remainder(t, 1461),
                t >= 366 && (u = 0,
                t--,
                r += div(t, 365),
                t = remainder(t, 365)),
                i = 0; t >= g_days_in_month[i] + (i == 1 && u) ; i++)
                    t -= g_days_in_month[i] + (i == 1 && u);
                return o = i + 1,
                s = t + 1,
                [r, o, s]
            }
            function padLeft(n, t, i) {
                return Array(t - String(n).length + 1).join(i || " ") + n
            }
            function toPersian(n) {
                return n = n.replace(/0/g, "۰"),
                n = n.replace(/1/g, "۱"),
                n = n.replace(/2/g, "۲"),
                n = n.replace(/3/g, "۳"),
                n = n.replace(/4/g, "۴"),
                n = n.replace(/5/g, "۵"),
                n = n.replace(/6/g, "۶"),
                n = n.replace(/7/g, "۷"),
                n = n.replace(/8/g, "۸"),
                n.replace(/9/g, "۹")
            }
            function getDay(n, t, i) {
                var r = new Date(n, t - 1, i);
                return r && ["یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه"][r.getDay()]
            }
        </script>
        <script>

        var chart = LightweightCharts.createChart(document.body, {
            width: 1600,
            height: 800,
            layout: {
                //backgroundColor: '#FAEBD7',
                //textColor: '#696969',
                fontSize: 12,
                fontFamily: 'WYekan',
            },
            priceScale: {
                scaleMargins: {
                    top: 0.1,
                    bottom: 0.1,
                },
                mode: LightweightCharts.PriceScaleMode.Logarithmic,
            },
            localization: {
                timeFormatter: function (n) {
                    console.log(n);
                    var i = n.year
                        , r = n.month
                        , u = n.day
                        , t = gregorian_to_jalali([i, r, u])
                        , f = t[0]
                        , e = t[1]
                        , o = t[2];
                    return toPersian(getDay(i, r, u) + " - " + f + "/" + e + "/" + o)
                },
            },
        });

        lineSeries = chart.addLineSeries({
            //color: 'rgba(38, 198, 218, 1)',
            lineWidth: 2,
        });

        volumeSeries = chart.addHistogramSeries({
            color: '#26a69a',
            lineWidth: 2,
            priceFormat: {
                type: 'volume',
            },
            overlay: true,
            scaleMargins: {
                top: 0.8,
                bottom: 0,
            },
        });

        lineSeries.setData( <%= PriceDataSerialized %> );
        volumeSeries.setData( <%= VolumeDataSerialized %> );

    </script>
    </form>
</body>
</html>
