import './App.css';
import "antd/dist/antd.css";
import { Link, Route, Router, Switch } from "react-router-dom";
import { Col, Layout, Menu, Row } from 'antd';
import { Content, Header } from 'antd/lib/layout/layout';
import { createBrowserHistory } from "history";
import Home from './pages/Home';
import Posts from './pages/Posts';
import Post from './pages/Post';

interface MenuItem {
  title: string;
  link: string;
}

function App() {
  const menuItems: MenuItem[] = [
    {
      title: "Home",
      link: "/",
    },
    {
      title: "Posts",
      link: "/posts",
    },
  ];

  return (
    <>
      <Router history={createBrowserHistory()}>
        <Layout>
          <Header className="header" style={{ height: "72px" }}>
            <Row>
              <Col span={24}>
                <Menu
                  mode="horizontal"
                  className="background-primary"
                  style={{ height: "73px" }}
                >
                  {menuItems.map((item) => (
                    <Menu.Item
                      key={item.link}
                      style={{ margin: "10px 0px" }}
                    >
                      <Link to={item.link}>{item.title}</Link>
                    </Menu.Item>
                  ))}
                </Menu>
              </Col>
            </Row>
          </Header>
          <Layout>
            <Layout style={{ padding: "0 24px 24px" }}>
              <Content
                className="site-layout-background"
                style={{
                  padding: 24,
                  margin: 0,
                  minHeight: 280,
                }}
              >
                <div className="container">
                  <div className="row p-3">
                    <Switch>
                      <Route path="/" exact>
                        <Home />
                      </Route>
                      <Route path="/posts" exact>
                        <Posts />
                      </Route>
                      <Route path="/post/:id" exact>
                        <Post />
                      </Route>
                    </Switch>
                  </div>
                </div>
              </Content>
            </Layout>
          </Layout>
        </Layout>
      </Router>
    </>
  );
}

export default App;
