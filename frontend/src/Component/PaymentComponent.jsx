import axios from "axios";
import { Container,Row,Col,Button,Modal,Form, ModalBody } from "react-bootstrap"



export default function PaymentComponent({payment,fetchPayments}){
    const handlePay = async () => {
       
        try {
            axios.put(`https://localhost:7179/payment/${payment.paymentId}`)
            fetchPayments();
        } catch (err) {
            console.log(err)
        }
    }


    return(
        <>
            <Col key={payment.paymentId} xs={12} className="">
                                <div
                                    className="d-flex justify-content-between align-items-center border rounded-3 px-3 py-3 shadow mb-2"
                                    style={{ background: "#fff", fontSize: "0.9rem" }}
                                    >                                    
                                    <div>
                                      
                                        <div className="d-flex flex-column ">
                                        <h5 className="fw-semibold">{payment.expenseName}</h5>
                                        <p className="text-secondary fw-semibold small">Payment to {payment.receiverUsername}</p>   
                                        </div>
                                    </div>

                                    <div className="d-flex flex-column gap-3 ">
                                  
                                        <p className="mb-0 fw-bold">Amount to pay: ${Number(payment.amount).toFixed(2)}</p>

                                        <div className="d-flex justify-content-end">
                                        <Button size="sm" className="flex-fill" onClick={() => handlePay()} >Pay</Button>
                                        </div>
   
                                    </div>
                                </div>  
                            </Col>
        </>
    )
}