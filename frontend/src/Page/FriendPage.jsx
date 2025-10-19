import axios from "axios";
import {  useEffect, useState } from "react"
import { Container,Row,Col,Button,Modal,Form, ModalBody } from "react-bootstrap"

export default function FriendPage(){
    
    const [show,setShow] = useState(false);
    const [username, setUsername] = useState("");
    const [error, setError] = useState("");
    const [friendList, setFriendList] = useState([]);
    const user = JSON.parse(localStorage.getItem("user"));
    console.log(user)

    const handleAddFriend = async (e) => {
        e.preventDefault();
        setError("");
        try {
            const res = await axios.post("http://localhost:5165/friend", {
                username: username.trim() },
                 {params: { userID: user.userId }}
            );

            await fetchFriend();
            setUsername("");
            setShow(false);
            console.log(res);
        } catch(error) {
            //setError(error.response.data)
            setError(String(error?.response?.data?.title ?? error?.response?.data ?? error?.message ?? "Failed to add friend"));
        }
    }

    const handleRemoveFriend = async (friendId) => {
        if (!window.confirm("Are you sure you want to remove this friend?")) return;

        try {
            const res = await axios.post("http://localhost:5165/friend/delete", null, {
                params: { userId: user.userId, friendId: friendId }
            });
            console.log(res);
            fetchFriend();
        } catch (error) {
            //setError(error.response.data)
            setError(String(error?.response?.data?.title ?? error?.response?.data ?? error?.message ?? "Failed to remove friend"));
        }
    }

    const fetchFriend = async () => {
        try{
            const res = await axios.get("http://localhost:5165/friend", {
                params: { userId: user.userId },
            });
            console.log(res.data);
            setFriendList(res.data);
        } catch(error) {
            console.log(error);
        }
    }
    
    useEffect(() => {fetchFriend();}, []);

    return(
        <>

        <Container>
            <Row>
                <Col className="d-flex align-items-center justify-content-between">
                    <h5 className="fw-bold">Friends</h5>
                    <Button size="sm" 
                            className="fw-bold rounded py-1 px-3"
                            onClick={() => {
                                setUsername("");
                                setShow(true);
                            }}
                    >Add Friend</Button>
                </Col>
            </Row> 
        </Container>

        <section className="mt-4">
            <Container>
            {friendList.length === 0 ? (
                <p className="text-muted">You have no friends! Add some friends.</p>
                ) : (
                    <Row className="gy-2">
                        {friendList.map((f) => (
                            <Col key={f.friendId} xs={12}>
                                <div
                                    className="d-flex justify-content-between align-items-center border rounded p-2"
                                    style={{ background: "#fff", fontSize: "0.9rem" }}
                                    >
                                    <div>
                                        <div className="d-flex align-items-center gap-2">
                                            <div className="fw-semibold">{f.friendUsername}</div>
                                            <span
                                                style={{
                                                    color: "red",
                                                    cursor: "pointer",
                                                    fontWeight: "bold",
                                                    fontSize: "1rem",
                                                    lineHeight: "1",
                                                }}
                                                title="Remove friend"
                                                onClick={() => handleRemoveFriend(f.friendId)}
                                            >
                                                ❌
                                            </span>
                                        </div>
                                        <div className="text-muted" style={{ fontSize: "0.85rem" }}>
                                            {f.name}
                                        </div>
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
                Add a Friend       
                </Modal.Title>
            </Modal.Header>    
            <ModalBody>
                <Form onSubmit={handleAddFriend}>
                    <Form.Group className="mb-3">
                        <Form.Label>Username</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="e.g Trip"
                            autoFocus
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                            required
                        />
                    </Form.Group>
                    
                    <div className="d-flex gap-2">
                        <Button variant="secondary" onClick={() => setShow(false)} className="flex-fill">Cancel</Button>
                        <Button onClick={() => setShow(false)} className="flex-fill" type="submit">Add</Button>
                    </div>
                </Form>
                {error === "" ? "" : <p className="text-danger">*{error}</p>}
            </ModalBody>
        </Modal>

        </>
    )
}