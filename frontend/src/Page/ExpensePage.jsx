import axios from "axios";
import {  useEffect, useState } from "react"
import { Container,Row,Col,Button,Modal,Form, ModalBody } from "react-bootstrap"

export default function ExpensePage(){
    const [show,setShow] = useState(false);
    const [expenseName, setExpenseName] = useState("");
    const [amount, setAmount] = useState("");
    const [error,setError] = useState("");
    const [expenseList, setExpenseList] = useState([]);
    const [expenseDate, setExpenseDate] = useState(null); //double check got from internet
    const user = JSON.parse(localStorage.getItem("user"));
    console.log(user)

    const handleCreateExpense = async (e) => {
        e.preventDefault();
        setError("");
        try {
            const res = await axios.post("https://localhost:7179/expense", {
                expenseName,
                expenseAmount: amount,
                expenseDate: new Date(expenseDate).toISOString(), //double check got from internet
                userId: user.userId
            });

            await fetchExpense();
            setExpenseName("");
            setAmount("");
            setExpenseDate(new Date().toISOString().slice(0, 10));
            setShow(false);
            console.log(res);
        } catch(error) {
            setError(error.response.data)
        }
    }

    const handleDeleteExpense = async (expenseId) => {
        if (!window.confirm("Are you sure you want to delete this expense?")) return;

        try {
            const res = await axios.post("https://localhost:7179/expense/delete", null, {
                params: { id: expenseId },
            });
            console.log(res)
            fetchExpense()
        } catch (error) {
            setError(error.response.data)
        }
    };

    const fetchExpense = async () => {
        try{
            const res = await axios.get("https://localhost:7179/expense", {
                params: { userId: user.userId },
            });
            console.log(res.data);
            setExpenseList(res.data);
        } catch(error) {
            console.log(error);
        }
    }

    useEffect(() => {fetchExpense();}, []);
    
    //build the page you get me 
    return(
        <>
        <Container>
            <Row>
                <Col className="d-flex align-items-center justify-content-between">
                    <h5 className="fw-bold">Expenses</h5>
                    <Button size="sm" 
                            className="fw-bold rounded py-1 px-3"
                            onClick={() => {
                                setExpenseName("");
                                setAmount("");
                                setExpenseDate(new Date().toISOString().slice(0, 10));
                                setShow(true);
                            }}
                    >Add Expense</Button>
                </Col>
            </Row> 
        </Container>

        <section className="mt-4">
            <Container>
            {expenseList.length === 0 ? (
                <p className="text-muted">No expenses yet. Create an Expense</p>
                ) : (
                    <Row className="gy-2">
                        {expenseList.map((exp) => (
                            <Col key={exp.expenseId} xs={12} className="">
                                <div
                                    className="d-flex justify-content-between align-items-center border rounded-3 px-3 py-3 shadow mb-2"
                                    style={{ background: "#fff", fontSize: "0.9rem" }}
                                    >                                    
                                    <div>
                                        {/* {exp.userId === user.userId && (
                                            <span
                                            style={{
                                                color: "red",
                                                cursor: "pointer",
                                                fontWeight: "bold",
                                                fontSize: "1rem",
                                                lineHeight: "1",
                                            }}
                                            title="Delete expense"
                                            onClick={() => handleDeleteExpense(exp.expenseId)}
                                            >
                                            ❌
                                            </span>
                                        )} */}
                                        <div className="d-flex flex-column ">
                                        <h5 className="fw-semibold">{exp.expenseName}</h5>
                                        <p className="text-secondary fw-semibold small">Requested by {exp.UserId == user.userId ? "You" : exp.ownerName}</p>   
                                        </div>
                                    
                                        <div className="text-muted">
                                        {new Date(exp.expenseDate).toLocaleDateString()}
                                        </div>
                                    </div>

                                    <div className="d-flex flex-column gap-5">
                                    <div className="fw-bold text-end">
                                        ${Number(exp.expenseAmount).toFixed(2)}
                                    </div>
                                    
                                       {exp.RequestAccept == null ? 
                                     <div className="d-flex gap-2"> 
                                        <Button variant="danger" size="sm">Reject</Button>
                                        <Button variant="success" size="sm">Accept</Button>
                                     </div> : 
                                        exp.RequestAccept == true ? <Button className="btn btn-lg btn-primary small" disabled>Accepted</Button>
                                        : <Button className="btn btn-lg btn-danger small" disabled>Accepted</Button>}
                                    </div>
                                </div>  
                            </Col>
                        ))}
                    </Row>
                )}
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
                        <Form.Label>Name</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="e.g Trip"
                            autoFocus
                            value={expenseName}
                            onChange={(e) => setExpenseName(e.target.value)}
                            required
                        />
                    </Form.Group>
                    <Form.Group classname="mb-3">
                        <Form.Label>Amount $</Form.Label>
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