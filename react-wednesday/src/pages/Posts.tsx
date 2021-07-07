import { Button, Table } from "antd";
import { ColumnsType } from "antd/lib/table";
import { Link } from "react-router-dom";
import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";

export interface PostInterface {
    userId: number;
    id: number;
    title: string;
    body: string;
}

export default function Posts() {
    const [posts, setPosts] = useState<PostInterface[]>([]);

    function deletePost(id: number) {
        setPosts(posts.filter(p => p.id !== id));
    }

    const columnPost: ColumnsType<PostInterface> = [
      {
        title: "User Id",
        render: (_, post: PostInterface) => post.userId,
        sorter: (a: PostInterface, b: PostInterface) => a.userId - b.userId,
        width: "5%",
      },
      {
        title: "Id",
        render: (_, post: PostInterface) => post.id,
        sorter: (a: PostInterface, b: PostInterface) => a.id - b.id,
        width: "5%",
      },
      {
        title: "Title",
        render: (_, post: PostInterface) => post.title,
        sorter: (a, b) => (a > b ? 1 : a === b ? 0 : -1),
        width: "20%",
      },
      {
        title: "Body",
        render: (_, post: PostInterface) => post.body,
        sorter: (a, b) => (a > b ? 1 : a === b ? 0 : -1),
        width: "60%",
      },
      {
        title: "Action",
        render: (_, post: PostInterface) => <>
            <Link to={`/post/${post.id}`}>Details</Link>
            <Button onClick={() => deletePost(post.id)}>Delete</Button>
        </>,
        width: "10%",
      },
    ];

    useEffect(() => {
        (async () => {
            const response: AxiosResponse = await axios.get("https://jsonplaceholder.typicode.com/posts");

            if (response.status === 200) {
                setPosts(response.data);
            }
        })();
    }, []);

    return (<>
        
        <Table
            dataSource={posts}
            columns={columnPost}
            scroll={{ y: 1200 }}
            rowKey={(record) => record.id}
        />
    </>);
}