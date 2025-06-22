create table if not exists accounts (
    id serial primary key,
    name varchar(100) not null,
    type varchar(20) check (type in ('cash', 'bank', 'credit_card', 'digital_wallet')) default 'cash',
    balance numeric(15,2) default 0,
    status varchar(8) check (status in ('active', 'inactive', 'deleted')) default 'active',
    created_at timestamp default current_timestamp,
    updated_at timestamp default current_timestamp
);

create table if not exists categories (
    id serial primary key,
    name varchar(100) not null
);

create table if not exists transactions (
    id serial primary key,
    type varchar(10) check (type in ('income', 'expense')) not null,
    amount numeric(15,2) not null,
    transaction_date date default current_date,
    description text,
    account_id integer not null references accounts(id) on delete cascade,
    category_id integer not null references categories(id) on delete cascade,
    created_at timestamp default current_timestamp,
    updated_at timestamp default current_timestamp
);

create table if not exists budgets (
    id serial primary key,
    category_id integer not null references categories(id) on delete cascade,
    amount numeric(15,2) not null,
    period varchar(20) check (period in ('monthly', 'weekly', 'yearly')) not null,
    created_at timestamp default current_timestamp,
    updated_at timestamp default current_timestamp
);

create or replace function update_updated_at()
returns trigger as $$
begin
    if old.* is distinct from new.* and old.updated_at is not distinct from new.updated_at then
        new.updated_at = now();
    end if;
    return new;
end;
$$ language plpgsql;

create trigger trigger_update_accounts_updated_at
before update on accounts
for each row
execute function update_updated_at();

create trigger trigger_update_transactions_updated_at
before update on transactions
for each row
execute function update_updated_at();

create trigger trigger_update_budgets_updated_at
before update on budgets
for each row
execute function update_updated_at();
