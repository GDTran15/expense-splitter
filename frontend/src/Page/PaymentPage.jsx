import axios from "axios";
import { useEffect, useState } from "react";
import { Container,Row,Col,Button,Modal,Form, ModalBody } from "react-bootstrap"

import PaymentComponent from "../Component/PaymentComponent";

export default function PaymentPage(){
    const user = JSON.parse(localStorage.getItem("user"));
    const [payments,setPayments] = useState([]);
    const fetchPayments = async () => {
       try{
        const res = await axios.get("https://localhost:7179/payment",{
            params: { userId: user.userId } 
        });
        console.log(res.data);
        setPayments(res.data);
       }catch(error){
        console.log(error);
       }
        
    }
    useEffect(() => {fetchPayments();},[]);
    
    return(
        <>


                <Container>
            <Row>
                <Col className="d-flex align-items-center justify-content-between">
                    <h5 className="fw-bold">Your Groups</h5>
                
                </Col>
            </Row>
        </Container>

        <section className="mt-5">
            <Container>
                <Row className="gap-3">
                    {payments && payments.map(payment => 
                        <PaymentComponent key={payment.paymentId} payment={payment}/>
                    )
                    }
                </Row>
            </Container>
            </section>
        </>
    )
}