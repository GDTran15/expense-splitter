import axios from "axios";
import {  useEffect, useState } from "react"
import { Container,Row,Col,Button,Modal,Form } from "react-bootstrap"

export default function ExpensePage(){
    const [show,setShow] = useState(false);
    const [amount, setAmount] = useState("");
    const [error,setError] = useState("");
    const [expenseDate, setExpenseDate] = useState(new Date().toISOString().slice(0, 10)); //double check got from internet

    const handleCreateExpense = async (e) => {
        e.preventDefault();
        setError("");
        try {
            const res = await axios.post("http://localhost:5165/expense", {
                expenseAmount: amount,
                expenseDate: new Date(expenseDate).toISOString(), //double check got from internet
                userId: user.userId
            });
            console.log(res);
        } catch(error) {
            setError(error.response.data)
        }
    }
    
    
    //build the page you get me 
    return(
        <>
        <h1>Expense</h1>
        </>
    )
}