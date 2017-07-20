
    function BugChart(el, option) {
        var myChart = echarts.init(document.getElementById(el));
        myChart.showLoading({
            text: '正在加载图表...',
            effect: 'bubble',
            textStyle: {
                fontSize: 20
            }
        });
        setTimeout(function () {
            myChart.hideLoading();
            myChart.setOption(option);
        }, 1200);
    }
    
    
    // 关闭维度
    function showBugChart(container,actName,one,two,three){ 
        BugChart(container, {
            title : {
                text: '项目BUG'+actName+'次数统计',
                subtext: actName+'次数',
                x:'center'
            },
            tooltip : {
                trigger: 'item',
                formatter: "{a} <br/>{b} : {c} ({d}%)"
            },
            legend: {
                orient: 'vertical',
                left: 'left',
                data: ['一次'+actName,'二次'+actName,'三次及以上'+actName]
            },
            series: [
                {
                    name: 'Bug'+actName+'次数统计',
                    type: 'pie',
                    radius : '60%',
                    center: ['50%', '60%'],
                    data:[
                        {value:one, name:'一次'+actName},
                        {value:two, name:'二次'+actName},
                        {value:three, name:'三次及以上'+actName}
                    ],
                    itemStyle: {
                        emphasis: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }
            ]
        });
    }
