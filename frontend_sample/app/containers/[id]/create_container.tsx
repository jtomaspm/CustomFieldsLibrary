'use client';

import { useState } from "react";

export default function CreateContainer(){
    const [code, setCode] = useState('');
    const [contType, setContType] = useState({});
    const [owner, setOwner] = useState({});
    return (
        <div>
            <h1>Create Container</h1>
            <form action="">
                <input 
                    type="text"
                    placeholder="Code"
                    value={code}
                    onChange={(e) => setCode(e.target.value)} 
                />
                <button type="submit">
                    Create
                </button>
            </form>
        </div>
    );
}