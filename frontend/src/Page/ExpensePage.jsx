import axios from "axios";
import {  useEffect, useState } from "react"
import { Container,Row,Col,Button,Modal,Form, ModalBody } from "react-bootstrap"

export default function ExpensePage(){
    const [show,setShow] = useState(false);
    const [amount, setAmount] = useState("");
    const [error,setError] = useState("");
    const [expenseList, setExpenseList] = useState([]);
    const [expenseDate, setExpenseDate] = useState(new Date().toISOString().slice(0, 10)); //double check got from internet
    const user = JSON.parse(localStorage.getItem("user"));
    console.log(user)

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

    const fetchExpense = async () => {
        try{
            const res = await axios.get("http://localhost:5165/expense", {
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
                    <Button size="sm" className="fw-bold rounded py-1 px-3"
                    onClick={() => setShow(true)}
                    >Add Expense</Button>
                </Col>
            </Row> 
        </Container>


        {/*add get method in backend then fetch here to dispaly expense*/}
        {/* <section classname="mt-4">
            <Container>
                <div classname="text-muted">

                </div>
            </Container>
        </section> */}
        <section className="mt-4">
        <Container>
          {expenseList.length === 0 ? (
            <p className="text-muted">No expenses yet. Add your first one!</p>
          ) : (
            <Row className="gy-2">
              {expenseList.map((exp) => (
                <Col key={exp.expenseId} xs={12}>
                  <div
                    className="d-flex justify-content-between align-items-center border rounded p-2"
                    style={{ background: "#fff", fontSize: "0.9rem" }}
                  >
                    <div>
                      <div className="fw-semibold">
                        Expense #{exp.expenseId}
                      </div>
                      <div className="text-muted">
                        {new Date(exp.expenseDate).toLocaleDateString()}
                      </div>
                    </div>
                    <div className="fw-bold text-end">
                      ${Number(exp.expenseAmount).toFixed(2)}
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