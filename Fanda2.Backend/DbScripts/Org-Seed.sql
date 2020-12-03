/**
* Cash on hand
* Purchase
* Sales
* Debit Note
* Credit Note
* Stock on hand
**/


SELECT l.id, l.code, l.ledger_name, l.ledger_desc, l.ledger_type, l.is_enabled, 
g.group_name 
FROM ledgers l 
INNER JOIN ledger_groups g ON l.group_id = g.id

SELECT l.*, 
b.ledger_id BankId, b.*, ba.id BankAddrId, ba.*, bc.id BankContactId, bc.*,  
p.ledger_id PartyId, p.*, pa.id PartyAddrId, pa.*, pc.id PartyContactId, pc.* 
FROM ledgers l 
LEFT JOIN banks b ON l.id = b.ledger_id 
    LEFT JOIN addresses ba ON b.address_id = ba.id 
    LEFT JOIN contacts bc ON b.contact_id = bc.id 
LEFT JOIN parties p ON l.id = p.ledger_id 
    LEFT JOIN addresses pa ON p.address_id = pa.id 
    LEFT JOIN contacts pc ON p.contact_id = pc.id 
WHERE l.id=@id
