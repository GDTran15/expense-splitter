import axios from "axios";
import { useEffect, useState } from "react"
import { ResponsiveContainer, PieChart, Pie, Tooltip, Legend, Cell } from "recharts";


export default function Chart() {
    const [data, setData] = useState([
        { name: "Pending ($)", value: 0 },
        { name: "Done ($)", value: 0 }
    ]);
    const [counts, setCounts] = useState({pending: 0, done: 0});
    const user = JSON.parse(localStorage.getItem("user"));
    const COLORS = ["#d84e4eff", "#4db86dff"]; 
    const formatMoney = (v) => `$${Number(v).toLocaleString()}`;

    useEffect(() => {
        const fetchData = async () => {
            try {
                const res = await axios.get("https://localhost:7179/analytics/summary", {
                    params: { userId: user.userId }
                });
                //const d = res.data;

                setData([
                    { name: "Pending ($)", value: res.data.pendingAmount },
                    { name: "Done ($)", value: res.data.doneAmount }
                ]);

                setCounts({pending: res.data.pendingCount, done: res.data.doneCount});
            } catch (error){
                console.log(error)
            }
        };
        fetchData();
    }, []);

    

    return (
        <div style={{ width: "100%", height: 280 }}>
            <ResponsiveContainer>
                <PieChart>
                    <Pie
                        data={data}
                        dataKey="value"
                        nameKey="name"
                        innerRadius={60}     
                        outerRadius={100}
                        label={(p) => `${p.name.split(" ")[0]}: ${formatMoney(p.value)}`}
                    >
                        {data.map((d, i) => (
                        <Cell key={i} fill={COLORS[i]} />
                        ))}
                    </Pie>
                    <Tooltip formatter={(v) => formatMoney(v)} />
                    <Legend />
                </PieChart>
            </ResponsiveContainer>

            <div className="d-flex justify-content-center gap-3 mt-2"
                style={{ fontWeight: "500" }}
            >
                <span style={{ color: "#4db86dff" }}>
                    Paid Expenses : {counts.done}
                </span>
                <span style={{ color: "#d84e4eff" }}>
                    Remaining Expenses: {counts.pending}
                </span>
                
            </div>
        </div>
        );

}