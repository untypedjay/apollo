import React from 'react';
import './ListItem.css';
import Button from '../atoms/Button';

interface Props {
  editAction: (item: any) => void;
  deleteAction: (item: any) => void;
  children: string;
}

function ListItem({ editAction, deleteAction, children }: Props) {
  return (
    <div className="list-item">
      <p className="list-item__text">{ children }</p>
      <Button onClick={() => editAction(children)} buttonType="transparent"></Button>
      <Button onClick={() => deleteAction(children)} buttonType="transparent"></Button>
    </div>
  );
}

export default ListItem;