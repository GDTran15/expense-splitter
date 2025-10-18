
import { Nav,Container,Row,Button } from 'react-bootstrap';
import style from '../css/navbar.module.css';
import { useState } from 'react';
import DashBoardPage from './DashBoardPage';
import GroupPage from './GroupPage';
import FriendPage from './FriendPage';
import ExpensePage from './ExpensePage';

export default function HomePage(){
    const [currentTab,setCurrentTab] = useState("dashboard");
    const user = JSON.parse(localStorage.getItem("user"));
    let mainContent;

switch (currentTab) {
  case "dashboard":
    mainContent = <DashBoardPage />;
    break;
  case "group":
    mainContent = <GroupPage />;
    break;
  case "friend":
    mainContent = <FriendPage />;
    break;
  case "expense":
    mainContent = <ExpensePage />;
    break;
  default:
    mainContent = <NotFFound />;
    }

    return (
        <>
       
        <nav className='bg-white  '>
            <div className={style.navbarBorder}>
                 <Container>
                <Row >
                    <div className=' d-flex align-content-center justify-content-between'>
               
                    <h3>Split That Thing</h3> 
                    <div className='d-flex align-items-center gap-2'>
                        <p className='mb-0'>Welcome, {user.userName}</p>
                        <Button size='sm'>Logout</Button>
                    </div>  
                    

                    </div>
                </Row>
            </Container>
            </div>
            <Container>
                <Nav
                activeKey="/home"
                onSelect={(selectedKey) => alert(`selected ${selectedKey}`)}
                
                >
                <Nav.Item> 
                    <Nav.Link className={currentTab == "dashboard" ? style.navtabActive : "text-secondary fw-semibold"} 
                    onClick={() => setCurrentTab("dashboard")}
                    >DashBoard</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                    <Nav.Link className={currentTab == "group" ? style.navtabActive : "text-secondary fw-semibold"}
                    onClick={() => setCurrentTab("group")}
                    >Groups</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                    <Nav.Link className={currentTab == "friend" ? style.navtabActive : "text-secondary fw-semibold"}
                    onClick={() => setCurrentTab("friend")}
                    >Friends</Nav.Link>

                </Nav.Item>
                <Nav.Item>
                    <Nav.Link className={currentTab == "expense" ? style.navtabActive : "text-secondary fw-semibold"}
                    onClick={() => setCurrentTab("expense")}
                    >
                    Expense
                    </Nav.Link>
                </Nav.Item>
            </Nav>
            </Container>
         </nav>
        
        <section className='mt-4'>
            {
                mainContent
            }
        </section>
       
            
             
        </>
    )
}