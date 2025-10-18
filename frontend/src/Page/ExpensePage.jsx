import axios from "axios";
import {  useEffect, useState } from "react"
import { Container,Row,Col,Button,Modal,Form, ModalBody } from "react-bootstrap"

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
        <Container>
            <Row>
                <Col className="d-flex align-items-center justify-content-between">
                    <h5 className="fw-bold">Expenses</h5>
                    <Button size="sm" className="fw-bold rounded py-1 px-3"
                    onClick={() => setShow(true)}
                    >Add Expense</Button>
                </Col>
            </Row> 
        </Container>


        {/*add get method in backend then fetch here to dispaly expense*/}
        <section classname="mt-4">
            <Container>
                <div classname="text-muted">

                </div>
            </Container>
        </section>

        <Modal        
            show={show}
            size="lg"
            aria-labelledby="contained-modal-title-vcenter"
            centered
            onHide={() => setShow(false)}
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                Create New Expense       
                </Modal.Title>
            </Modal.Header>    
            <ModalBody>
                <Form onSubmit={handleCreateExpense}>
                    <Form.Group classname="mb-3">
                        <Form.Label>Amount</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="e.g Trip"
                            autoFocus
                            value={amount}
                            onChange={(e) => setAmount(e.target.value)}
                            required
                        />
                    </Form.Group>
                     <Form.Group className="mb-3 flex-fill">
                        <Form.Label>Date</Form.Label>
                        <Form.Control
                        type="date"
                        value={expenseDate}
                        onChange={(e) => setExpenseDate(e.target.value)}
                        required
                        />
                    </Form.Group>
                    <div className="d-flex gap 2">
                        <Button variant="secondary" onClick={() => setShow(false)} className="flex-fill">Cancel</Button>
                        <Button onClick={() => setShow(false)} className="flex-fill" type="submit">Create</Button>
                    </div>
                </Form>
                {error === "" ? "" : <p className="text-danger">*{error}</p>}
            </ModalBody>
        </Modal>
        
        
        </>
    )
}