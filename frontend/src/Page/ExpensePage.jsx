import axios from "axios";
import {  useEffect, useState } from "react"
import { Container,Row,Col,Button,Modal,Form, ModalBody } from "react-bootstrap"
import ExpenseComponent from "../Component/ExpenseComponent";
import OwnExpenseComponent from "../Component/OwnExpenseComponent";

export default function ExpensePage(){
    const [show,setShow] = useState(false);
    const [expenseName, setExpenseName] = useState("");
    const [amount, setAmount] = useState("");
    const [expenseList, setExpenseList] = useState([]);
<<<<<<< HEAD
    const [ownExpense,setOwnExpense] = useState([])
    
    const [shareOption,setShareOption] = useState("");  
    const [friendOrGroupList, setFriendOrGroupList] = useState([]);
    const [chooseLabel, setChooseLabel] = useState("");
    const [userToShare,setUserToShare] = useState(undefined);
   

=======
    const [expenseDate, setExpenseDate] = useState(null); 
>>>>>>> a2ae379a183e281a088a27d9b8c23a21d74a149d
    const user = JSON.parse(localStorage.getItem("user"));



 

    const handleCreateExpense = async (e) => {
        e.preventDefault();
        
        try {
<<<<<<< HEAD
            const res = await axios.post("https://localhost:7179/expense", {
                
                expenseAmount: amount,
                userId: user.userId,
                expenseName: expenseName,
                shareOption: shareOption,
                friendOrGroupId : userToShare
=======
            const res = await axios.post("http://localhost:5165/expense", {
                expenseName,
                expenseAmount: amount,
                expenseDate: new Date(expenseDate).toISOString(), 
                userId: user.userId
>>>>>>> a2ae379a183e281a088a27d9b8c23a21d74a149d
            });
            console.log(userToShare);
            await fetchExpense();
            setExpenseName("");
            setAmount("");
           
            setShow(false);
            console.log(res);
        } catch(error) {
            console.log(error.response.data)
        }
    }

    const handleOptionChange = async (e) => {
        const selectedOption = e.target.value;
        setShareOption(selectedOption);
        setFriendOrGroupList([])
        setChooseLabel("");

<<<<<<< HEAD
        let url = "";
        switch(selectedOption){
            case "friend":
                url = "https://localhost:7179/friend";
                setChooseLabel("Choose friend to share");
                break;
            case "group":
                 url = "https://localhost:7179/group";
                setChooseLabel("Choose group to share");
                break;
            default:
                url = "";
           
            }
             if(url){
                try {
               const res = await axios.get(url,{
                    params: {userId : user.userId}
                });
                console.log(res)
                setFriendOrGroupList(res.data)
                fetchOwnExpense();
            } catch (error){
                console.log(error)
            }
=======
        try {
            const res = await axios.post("http://localhost:5165/expense/delete", null, {
                params: { id: expenseId },
            });
            console.log(res);
            fetchExpense();
        } catch (error) {
            setError(error.response.data)
>>>>>>> a2ae379a183e281a088a27d9b8c23a21d74a149d
        }


    }
    const handleItemChoose = (e) => {
        setUserToShare(e.target.value)
    }

   

    const fetchExpense = async () => {
        try{
<<<<<<< HEAD
            const res = await axios.get("https://localhost:7179/expense/share-request-user", {
=======
            const res = await axios.get("http://localhost:5165/expense", {
>>>>>>> a2ae379a183e281a088a27d9b8c23a21d74a149d
                params: { userId: user.userId },
            });
            console.log(res);
            setExpenseList(res.data);
        } catch(error) {
            console.log(error);
        }
    }

     const fetchOwnExpense = async () => {
        try{
            const res = await axios.get("https://localhost:7179/expense", {
                params: { userId: user.userId },
            });
            console.log(res);
            setOwnExpense(res.data);
        } catch(error) {
            console.log(error);
        }
    }

    useEffect(() => {fetchExpense();}, []);
    useEffect(() => {fetchOwnExpense();}, []);
    
    //build the page you get me 
    return(
        <>
        <Container>
            <Row>
                <Col className="d-flex align-items-center justify-content-between">
                    <h5 className="fw-bold mb-0">Expenses</h5>
                    <Button size="sm" 
                            className="fw-bold rounded py-1 px-3"
                            onClick={() => {
                                setExpenseName("");
                                setAmount("");
                                
                                setShow(true);
                            }}
                    >Add Expense</Button>
                </Col>
            </Row> 
        </Container>

        <section className="mt-4">
            <Container>
            
            {expenseList.length === 0 && ownExpense.length === 0? (
                <p className="text-muted">No expenses yet. Create an Expense</p>
                ) : (
                    <Row className="gy-2">
                        {expenseList.map((exp) => (
<<<<<<< HEAD
                            <ExpenseComponent exp={exp} fetchExpense={fetchExpense}/>
                        ))}
                        {ownExpense.map((exp) => (
                            <OwnExpenseComponent exp={exp}/>
=======
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
>>>>>>> a2ae379a183e281a088a27d9b8c23a21d74a149d
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
            <ModalBody >
                <Form onSubmit={handleCreateExpense}>
<<<<<<< HEAD
                    <Form.Group >
                        <Form.Label className="mt-2">Name</Form.Label>
=======
                    <Form.Group className="mb-3">
                        <Form.Label>Name</Form.Label>
>>>>>>> a2ae379a183e281a088a27d9b8c23a21d74a149d
                        <Form.Control
                            type="text"
                            placeholder="e.g Trip"
                            autoFocus
                            value={expenseName}
                            onChange={(e) => setExpenseName(e.target.value)}
                            required
                        />
                    </Form.Group>
<<<<<<< HEAD
                    <Form.Group >
                        <Form.Label className="mt-2">Amount $</Form.Label>
=======
                    <Form.Group className="mb-3">
                        <Form.Label>Amount $</Form.Label>
>>>>>>> a2ae379a183e281a088a27d9b8c23a21d74a149d
                        <Form.Control
                            type="text"
                            placeholder="e.g 10000"
                            autoFocus
                            value={amount}
                            onChange={(e) => setAmount(e.target.value)}
                            required
                            className=""
                        />
                    </Form.Group>
<<<<<<< HEAD
                    <Form.Group >
                        <Form.Label className="mt-2">Share option </Form.Label>
                        <Form.Select onChange={handleOptionChange}>
                        <option selected>Open this select menu</option>
                        <option value="friend">Friend</option>
                        <option value="group">Group</option>
                        </Form.Select>
                    </Form.Group>
                    { shareOption != ""? 
                            <Form.Group >
                    <Form.Label className="mt-2">{chooseLabel}</Form.Label>
                        <Form.Select onChange={handleItemChoose}>
                            <option selected>Open this select menu</option>
                         {friendOrGroupList.map(item => (
                            <option value={item.friendId || item.groupId}>{item.groupName || item.friendName}</option>
                         ))} 
                        </Form.Select>
                    </Form.Group>
                   
                      : "" }
                       
                    
                    <div className="d-flex gap-2 mt-3">
=======
                     <Form.Group className="mb-3">
                        <Form.Label>Date</Form.Label>
                        <Form.Control
                        type="date"
                        value={expenseDate}
                        onChange={(e) => setExpenseDate(e.target.value)}
                        required
                        />
                    </Form.Group>
                    <div className="d-flex gap-2">
>>>>>>> a2ae379a183e281a088a27d9b8c23a21d74a149d
                        <Button variant="secondary" onClick={() => setShow(false)} className="flex-fill">Cancel</Button>
                        <Button onClick={() => setShow(false)} className="flex-fill" type="submit">Create</Button>
                    </div>
                </Form>
              
            </ModalBody>
        </Modal>
        
        

        </>
    )
}