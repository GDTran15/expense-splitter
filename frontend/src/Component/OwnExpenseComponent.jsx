
import axios from "axios";
import { useState } from "react";
import { Col,Button,Modal } from "react-bootstrap";

export default function ExpenseComponent({exp}){
    //const user = JSON.parse(localStorage.getItem("user"));
    const [show,setShow] = useState(false);
    const [userResponses,setUserResponses] = useState([]);
    const [complete,setComplete] = useState(false);

    const handleViewResponse = async () =>{
        setShow(true)
        try {
           const res = await axios.get(`https://localhost:7179/share-request/${exp.shareId}`)
            setUserResponses(res.data);
        } catch (error) {
            console.log(error)
        }
    }
    const handleExpenseComplete = async () => {
        try {
            await axios.put(`https://localhost:7179/expense/${exp.expenseId}`)
            setComplete(true);
        } catch (error) {
             console.log(error)
        }
    }

    return(
        <>
        <Col key={exp.expenseId} xs={12} className="">
                                <div
                                    className="d-flex justify-content-between align-items-center border rounded-3 px-3 py-3 shadow mb-2"
                                    style={{ background: "#fff", fontSize: "0.9rem" }}
                                    >                                    
                                    <div>
                                      
                                        <div className="d-flex flex-column ">
                                        <h5 className="fw-semibold">{exp.expenseName}</h5>
                                        <p className="text-secondary fw-semibold small">Your request</p>   
                                        </div>
                                    
                                        <div className="text-muted">
                                        {new Date(exp.expenseDate).toLocaleDateString()}
                                        </div>
                                    </div>

                                    <div className="d-flex flex-column gap-3 ">
                                  
                                        <p className="mb-0 fw-bold ms-auto">Expense amount: ${Number(exp.expenseAmount).toFixed(2)}</p>

                                        <div className="d-flex gap-2">
                                            {complete == false ? <Button size="sm" variant="success" onClick={() => handleExpenseComplete()}>Expense complete</Button> 
                                            : <Button size="sm" variant="success" disabled>Completed</Button>}
                                            
                                        <Button size="sm" onClick={() => handleViewResponse()}>View Current Response</Button>
                                        </div>
                                        

   
                                    </div>
                                </div>  
                            </Col>
                            
                            
                            <Modal
                            show={show}
                            size="lg"
                            aria-labelledby="contained-modal-title-vcenter"
                            centered
                            onHide={() => setShow(false)}
                            >
                            <Modal.Header closeButton>
                                <Modal.Title id="contained-modal-title-vcenter">
                                Current response
                                </Modal.Title>
                            </Modal.Header>
                            <Modal.Body>
                                {userResponses.map(userResponse => (
                                    <ul>
                                    <li key={userResponse.userId}>
                                        <p className="mb-0 fw-semibold d-inline-block">{userResponse.username}</p>
                                        
                                        {userResponse.isAccepted == null ? <p className="ms-3 mb-0 d-inline-block text-warning fw-light fst-italic small">Waiting for response</p> :
                                        userResponse.isAccepted == true ? <p className="ms-3 mb-0 d-inline-block text-success fw-light fst-italic small">Accepted</p> :
                                        <p className="ms-3 mb-0 d-inline-block text-danger fw-light fst-italic small">Rejected</p> }
                                    </li>
                                    </ul>
                                ))}
                            </Modal.Body>
                            </Modal>
                            </>
    )
}